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

        public Task<Dictionary<Product, int>> GetProductOrdersCountDictionary()
        {
            var productsOrdered = _db.Orders.SelectMany(x => x.Products);

            var results = productsOrdered.GroupBy(x => x.Id);

            return null;          
        }

        public Task<IEnumerable<Product>> GetMostRecentProducts(int count)
        {
            throw new System.NotImplementedException();
        }
    }
}
