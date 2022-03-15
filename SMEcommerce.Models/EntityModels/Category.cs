using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMEcommerce.Models.EntityModels
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        //public Item ItemId { get; set; }
        [NotMapped]
        public Item Item { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public string Code { get; set; }
        
    }
}
