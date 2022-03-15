using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Models.EntityModels.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Address { get; set; }
    }
}
