using System;
using System.Collections.Generic;

namespace OnlineStore.Business.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<CartProductDTO> ProductVms { get; set; }
    }
}