using System;
using System.Collections.Generic;

namespace lab234.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetils { get; set; }
    }
}