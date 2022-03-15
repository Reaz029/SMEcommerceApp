using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SMEcommerceApp.Models.ProductModels
{
    
    public class ProductCreate
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime ManufacturerDate { get; set; }
       // public  Category Category { get; set; }
        public int? CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        public IFormFile ImageFile { get; set; }

        //[Required]
        //[Display(Name = "Image")]
        //public IFormFile ProductImage { get; set; }


        // public Category Category { get; set; }
        //public ICollection<Item> Itemlist { get; set; }
    }
}
