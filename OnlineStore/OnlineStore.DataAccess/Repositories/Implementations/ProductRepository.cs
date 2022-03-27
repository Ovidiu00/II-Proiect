using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext _db) : base(_db)
        {
        }

        public async Task<Dictionary<Product, int>> GetProductOrdersCountDictionary()
        {
            ///TODO : once order module is implemented
            ///
            //var productsOrdered = _db.Orders.SelectMany(x => x.Products);

            //var results = productsOrdered.GroupBy(x => x.Id);

            var dictionary = new Dictionary<Product, int>();
            var popularProducts = await _db.Products.ToListAsync();

            var contor = 2;
            foreach(var product in popularProducts)
            {
                dictionary.Add(product, contor);
                contor = contor + 3;
            }

            return dictionary;
        }

        public async Task<IEnumerable<Product>> GetMostRecentProducts(int count)
        {
            return await _db.Products.OrderByDescending(product => product.InsertedDate).Take(count).ToListAsync();
        }
        
    }
}
