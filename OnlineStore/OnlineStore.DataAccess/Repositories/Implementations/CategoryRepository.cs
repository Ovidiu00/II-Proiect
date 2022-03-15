using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Models.AppDbContext;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(OnlineStoreDbContext _db) : base(_db)
        {

        }

        public async Task<Category> GetCategory(int id)
        {
            return await _db.Categories.Include(category => category.SubCategories)
                .FirstOrDefaultAsync(category => category.Id.Equals(id));
        }

        public async Task<Category> GetCategoryWithProducts(int id)
        {
            return await _db.Categories.Include(x => x.Products).FirstOrDefaultAsync(y => y.Id == id);
        }


    }
}
