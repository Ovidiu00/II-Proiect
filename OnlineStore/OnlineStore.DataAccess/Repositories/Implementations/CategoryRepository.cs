using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories.Interfaces;

namespace OnlineStore.DataAccess.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(OnlineStoreDbContext _db):base(_db)
        {

        }  
    }
}
