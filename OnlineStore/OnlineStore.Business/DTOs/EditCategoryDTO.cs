using Microsoft.AspNetCore.Http;

namespace OnlineStore.Business.DTOs
{
    public class EditCategoryDTO
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}