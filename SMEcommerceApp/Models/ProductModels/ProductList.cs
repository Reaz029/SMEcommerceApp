using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMEcommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Models.ProductModels
{
    public class ProductList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Item> ItemList { get; set; }
        
        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }
       // public IFormFile ProductImage { get; set; }
      //  public int? CategoryId { get; set; }
       // public SelectList CategoryList { get; set; }
    }
}
