using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories.Interfaces;

namespace OnlineStore.DataAccess.Repositories.Implementations
{
    public class OrderRepository :  BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreDbContext _db):base(_db)
        {

        } 
    }
}
