using Microsoft.AspNetCore.Mvc;
using SMEcommerceApp.Models.ContactModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Controllers
{
    public class ContactController : Controller
    {



        public string Index()
        {
            return "This is the default ACTION";
        }


        //public IActionResult Address(Address1 address)
        //{

        //}
        public IActionResult Address()
        {
            ViewBag.title = "Your contact page.";

            var viewModel = new Address()
            {
                Name = "Microsoft",
                Street = "One Microsoft Way",
                City = "Redmond",
                State = "WA",
                PostalCode = "98052-6399"
            };

            return View(viewModel);
        }
    }
}
