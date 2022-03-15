using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMEcommerce.Models.EntityModels
{
    // To change the Items model name into products [Table("Products")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ManufacturerDate { get; set; }
        public Category Category { get; set; }

        public int CategoryId { get; set; }
        public string Code { get; set; }
        [DisplayName("Upload Image")]
         public string ImagePath { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ProductImage { get; set; }

        //  public  MyProperty { get; set; }


    }
}

