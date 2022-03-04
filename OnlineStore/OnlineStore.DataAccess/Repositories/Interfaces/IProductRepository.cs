using OnlineStore.DataAccess.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Dictionary<Product, int>> GetProductOrdersCountDictionary();

        Task<IEnumerable<Product>> GetMostRecentProducts(int count);
    }
}
