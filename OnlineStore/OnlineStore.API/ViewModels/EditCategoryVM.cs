using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.API.ViewModels
{
    public class EditCategoryVM
    {
        [Required]
        public string Name { get; set; }
        public IFormFile Photo { get; set; }

    }
}