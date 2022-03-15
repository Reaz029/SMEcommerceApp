using SMEcommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Models.CategoryModels
{
    public class CategoryListVM
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Item> ItemList { get; set; }
        public virtual Item Item { get; set; }

    }
}
