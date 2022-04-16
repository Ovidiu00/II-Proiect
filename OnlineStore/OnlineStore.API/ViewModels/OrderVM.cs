using System.Collections.Generic;

namespace OnlineStore.API.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public IEnumerable<CartProductVM> ProductVms { get; set; }
    }
}