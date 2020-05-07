using System;
//using lab234.Models;

namespace lab234.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImage { get; set; }
        public double ProductPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public string Descriptions { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}