using OnlineStore.DataAccess.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<UserProduct>> GetProductsInCart(string userId);
        Task<IEnumerable<Order>> GetOrders(string userId);
        void RemoveItemsFromCart(string userId);
    }
}
