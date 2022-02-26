using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<IList<T>> Find(Expression<Func<T, bool>> expression);
        Task<int> Count();
        void Add(T entity);
        void AddRange(IList<T> list);
        void Delete(T entity);
        void DeleteRange(ICollection<T> list);
 
        Task<T> FindSingle(Expression<Func<T, bool>> expression);
        void UpdateIfModified<T>(T existingEntity, T modifiedExistingEntity, string nameOfPrimaryKeyProperty) where T : class;
    }
}
