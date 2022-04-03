using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.ViewModels
{
    public class EditCategoryVM
    {
        
        public string Name { get; set; }
        public IFormFile Photo { get; set; }

    }
}