using System.Collections.Generic;

namespace OnlineStore.Business.DTOs
{
    public  class CategoryDTO
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }       
        
        public IEnumerable<CategoryDTO> Subcategories { get; set; }
    }
}
