using OnlineStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();

        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository  ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }

    }
}
