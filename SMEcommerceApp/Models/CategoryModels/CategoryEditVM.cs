using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Models.CategoryModels
{
    public class CategoryEditVM
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
       // public Double Price { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
