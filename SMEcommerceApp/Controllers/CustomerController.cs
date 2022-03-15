using Microsoft.AspNetCore.Mvc;
using SMEcommerceApp.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var customer = new Customer()
            {
                Code = "001",
                Name = "Reaz"
            };
            return View(customer);
            
        }

    }
}
