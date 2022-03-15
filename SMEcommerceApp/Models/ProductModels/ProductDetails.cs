using SMEcommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Models.ProductModels
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ManufactureDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
