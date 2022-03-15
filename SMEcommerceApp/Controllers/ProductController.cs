using EFcoreExamples.Repositories;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Services.Abstraction;
using SMEcommerceApp.Models.CategoryModels;
using SMEcommerceApp.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        // SMEcommerceDbContext db;

        private readonly IWebHostEnvironment _hostEnvironment;


        IProductService _productService;
        ICategoryService _categoryService;
        public ProductController(IWebHostEnvironment hostEnvironment,IProductService ProductService,ICategoryService CategoryService)
        {
            _productService = ProductService;
            _categoryService = CategoryService;
            _hostEnvironment = hostEnvironment;
            //_ItemRepository = new ItemRepository();
            //_CategoryRepository = new CategoryRepository();
            //db = new SMEcommerceDbContext();
        }

        public string Index()
        {
            {
                return "This is the default ACTION";
            }
        }



        public IActionResult Create()
        {

          
             ProductCreate model = new ProductCreate();

            //CategoryRepository categoryRepository = new CategoryRepository();

            ConfigureViewModel(model);
           
            return View(model);
            


            

        }




        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate model)
        {

           // IProductService itemrepositopry = new ItemRepository();

            var categorylist = _categoryService.GetAll();

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);

            fileName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.ImagePath = "~/Image/" + fileName;
            string path = Path.Combine(wwwRootPath + "/image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }
            if (model.Name != null)
            {
                var item = new Item()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,

                    Code = model.Code,


                    CategoryId = model.CategoryId.Value,
                    
                    ImagePath = model.ImagePath


                   // ProductImage = model.ProductImage
                   
                    

                };
                




                // string wwwRootPath = _hostEnvironment.WebRootPath;
                // string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                // string extension = Path.GetExtension(model.ImageFile.FileName);
                // fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                // model.ImagePath = wwwRootPath + "/Image/" + fileName;
                // fileName = Path.Combine(Server.MapPath("~/wwwroot"), fileName);
                // model.ImageFile.SaveAs(fileName);
                //// string path = Path.Combine(, fileName);
                // //model.ProductImage.SaveAs(fileName);
                // using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    //await model.ProductImage.CopyToAsync(fileStream);
                //    await model.ImageFile.CopyToAsync(fileStream);
                //}
                model.ManufacturerDate = DateTime.Now;
                var isAdded = _productService.Add(item);
                
                if (isAdded)
                {
                    return RedirectToAction("List");
                }
            }
            return View();

        }


        private void ConfigureViewModel(ProductCreate model)
        {
           // SMEcommerceDbContext db;
            List<Category> CategoryList = _categoryService.GetAll().ToList();
            model.CategoryList = new SelectList(CategoryList, "Id", "Name");
        }

     


        public IActionResult List()
        {
            var productlist = _productService.GetAll();
            
            var ItemListVm = new ProductList()
            {
                Title = "Product",
                Description = "Product Description",
                
                ItemList = productlist.ToList()
              
             
               
                
     
           
              };
           
           





            return View(ItemListVm);
          
        }

        public IActionResult Details(int? id)
        {
            var item = _productService.GetById((int)id);

            var itemDetails = new ProductDetails()
            {
                Code = item.Code,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                ManufactureDate = item.ManufacturerDate,
                CategoryId = item.Category.Name,
                ImagePath = item.ImagePath



            };
            return View(itemDetails);
        }


        public IActionResult Edit(int? id)
        {
            ProductEdit model = new ProductEdit();
           
            if (id==null)
            {
                return RedirectToAction("List");

            }
            var product = _productService.GetById((int)id);
            if(product==null)
            {
                return RedirectToAction("List");
            }
            var categorylist = _categoryService.GetAll().ToList();
            
            var productEditVm = new ProductEdit()
            {
                Id = product.Id,
                Name = product.Name,

                Code = product.Code,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                ManufacturerDate = product.ManufacturerDate,
                CategoryId = product.CategoryId,
                CategoryList = categorylist
                

            };
            

            return View(productEditVm);
        }

        [HttpPost]
        public IActionResult Edit(ProductEdit model)
        {
            if(ModelState.IsValid)
            {
                var product = new Item
                {
                    Id = model.Id,
                    Name = model.Name,
                    Code = model.Code,
                    Description = model.Description,
                    Category = model.Category,
                    Price = model.Price,
                    ManufacturerDate = model.ManufacturerDate,
                   CategoryId = model.CategoryId,
                   ImagePath = model.ImagePath
                };
            
                bool isUpdated = _productService.Update(product);

                if(isUpdated)
                {
                    return RedirectToAction("List");
                }
                
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("List");

            }
            var product = _productService.GetById((int)id);
            if(id==null)
            {
                return RedirectToAction("List");

            }
            bool isRemoved = _productService.Remove(product);
            if(isRemoved)
            {
                return RedirectToAction("List");
            }
            return View("List");
        }

       

        //public string GetCategoryNameByID(int id)
        //{
        //    string name = db.Categories.Where(c => c.Id==id).First().Name;

        //    return name;
        //}


        //private void ConfigureViewModelq(ProductList model)
        //{
        //    // SMEcommerceDbContext db;
        //    var CategoryList = db.Categories.ToList();
        //    model.CategoryList = new SelectList(CategoryList, "Id", "Name");
        //}
        //private void ConfigureViewModeltg(Category model)
        //{
        //    // SMEcommerceDbContext db;
        //    var category = category;
        //    List<Category> CategoryList = db.Categories.ToList();
        //    //odel.CategoryList = new SelectList(CategoryList,"Name");
        //    //model.Name =;
        //}
    }
}
