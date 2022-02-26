using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Models.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly OnlineStoreDbContext _db;

        public BaseRepository(OnlineStoreDbContext _db)
        {
            this._db = _db;
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }
        public void AddRange(IList<T> list)
        {
            _db.Set<T>().AddRange(list);
        }

        public async Task<int> Count()
        {
            return await _db.Set<T>().CountAsync();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
        public void DeleteRange(ICollection<T> list)
        {
            _db.Set<T>().RemoveRange(list);
        }


        public async Task<IList<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _db.Set<T>().Where(expression).ToListAsync();
        }
       
        public async Task<T> Get(Object id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<IList<T>> GetAll()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        

        public async Task<T> FindSingle(Expression<Func<T, bool>> expression)
        {
            return (await _db.Set<T>().Where(expression).ToListAsync()).FirstOrDefault();

        }
       


        /// <summary>
        /// Modified existing entity's proprieites and changes are reflected when SaveChanges is called.Long story short : Overrides the existing entity with the new entity given as parameter.
        /// Only applies to Value type, string proprieties and nullabels

        /// </summary>
        /// <param name="existingEntity">Entity that was retrieved from DB (actual values live in DB).If it is not tracked by the context already, it will be tracked after calling this method</param>
        /// <param name="modifiedExistingEntity">Entity recieved in http PUT endpoint or which the client knows exist in DB</param>
        /// <param name="nameOfPrimaryKeyProperty">Name of the primary key, the primary key property will be ignored when checking for changes</param>
        public void UpdateIfModified<T>(T existingEntity, T modifiedExistingEntity, string nameOfPrimaryKeyProperty) where T : class
        {
            var proprieties = GetProprietiesExceptPrimaryKey(existingEntity, nameOfPrimaryKeyProperty);


            foreach (var property in proprieties)
            {
                if (IsValueTypeOrString(property) == false)
                    continue;


                object valueExistingEmployee = GetValueForProperty(property, existingEntity);
                object valueExistingEmployeeModified = GetValueForProperty(property, modifiedExistingEntity);

                if (valueExistingEmployee == null)
                    _db.Entry(existingEntity).Property(property.Name).CurrentValue = valueExistingEmployeeModified;


                if (valueExistingEmployee != null && !valueExistingEmployee.Equals(valueExistingEmployeeModified))
                    _db.Entry(existingEntity).Property(property.Name).CurrentValue = valueExistingEmployeeModified;
            }
        }

        PropertyInfo[] GetProprietiesExceptPrimaryKey<T>(T existingEntity, string nameOfPrimaryKeyProperty) where T : class
        {
            PropertyInfo[] propritiesOfExistingEntity = existingEntity.GetType().GetProperties();

            return propritiesOfExistingEntity.Where(property => property.Name != nameOfPrimaryKeyProperty).ToArray();
        }

        object GetValueForProperty<T>(PropertyInfo property, T entity) where T : class
        {
            return typeof(T).GetProperty(property.Name).GetValue(entity);
        }

        /// <summary>
        /// Not taking into consideration if the reference property has changed since only the foreign key prop is relevant.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static bool IsValueTypeOrString(System.Reflection.PropertyInfo property)
        {
            return (property.PropertyType == typeof(string) || property.PropertyType.IsValueType);
        }
    }
}
