using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreDbContext _db) : base(_db)
        {

        }

        public async Task<IEnumerable<Order>> GetOrders(string userId)
        {
            return await _db.Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.Products).ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserProduct>> GetProductsInCart(string userId)
        {
            return await _db.UserProducts
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public void RemoveItemFromCart(UserProduct cartItemToBeRemoved)
        {
            _db.UserProducts.Remove(cartItemToBeRemoved);
            _db.SaveChanges();
        }

        public void RemoveItemsFromCart(string userId)
        {
            var itemsInCart = _db.UserProducts.Where(x => x.UserId == userId);
            _db.RemoveRange(itemsInCart);
        }
    }
}
