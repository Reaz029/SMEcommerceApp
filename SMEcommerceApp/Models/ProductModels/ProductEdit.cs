using Microsoft.AspNetCore.Mvc.Rendering;
using SMEcommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Models.ProductModels
{
    public class ProductEdit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime ManufacturerDate { get; set; }
        
        public string Description { get; set; }
        public string Code { get; set; }

        //public Category Category { get; set; }

        public  Category Category { get; set; }

        public int CategoryId { get; set; }
        public List<Category> CategoryList { get; set; }

        public string ImagePath { get; set; }
    }
}
