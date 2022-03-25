using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.ViewModels
{
    public class AddProductVM
    {
        public IFormFile photo { get; set; }
    }
}
