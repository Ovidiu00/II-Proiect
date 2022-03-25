using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs
{
    class AddProductDTO
    {
        public IFormFile photo { get; set; }
    }
}
