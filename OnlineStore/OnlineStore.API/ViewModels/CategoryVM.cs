using System.Collections.Generic;

namespace OnlineStore.API.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryVM> SubCategories { get; set; }

    }
}
