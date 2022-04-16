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

        public async Task<IEnumerable<UserProduct>> GetProductsInCart(string userId)
        {
            return await _db.UserProducts.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
