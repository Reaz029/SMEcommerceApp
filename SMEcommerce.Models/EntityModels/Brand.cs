using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMEcommerce.Models.EntityModels
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public virtual Category Category { get; set; }


        public int CategoryId { get; set; }

        public virtual List<Item> Items { get; set; }




    }
}
