using OnlineStore.DataAccess.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<UserProduct>> GetProductsInCart(string userId);
    }
}
