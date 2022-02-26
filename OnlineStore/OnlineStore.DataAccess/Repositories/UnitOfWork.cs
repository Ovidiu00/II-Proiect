using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Repositories.Implementations;
using OnlineStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDbContext db;

        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;


        public UnitOfWork(OnlineStoreDbContext db)
        {
            this.db = db;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return categoryRepository = categoryRepository ?? new CategoryRepository(db);

            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return productRepository = productRepository ?? new ProductRepository(db);

            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                return orderRepository = orderRepository ?? new OrderRepository(db);

            }
        }

        public async Task Commit()
        {
            await db.SaveChangesAsync();
        }

        
    }
}
