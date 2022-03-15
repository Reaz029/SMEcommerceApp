using AutoMapper;
using EFcoreExamples.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Services.Abstraction;
using SMEcommerceApp.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICategoryService = SMEcommerce.Services.Abstraction.ICategoryService;

namespace SMEcommerceApp.Controllers
{
    
  
    public class CategoryController : Controller
    {

        // SMEcommerce.Services.Abstraction.ICategoryService _categoryService;
        ICategoryService _categoryService;
        IProductService _productService;
        IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper,IProductService productService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _productService = productService;
        }
        public string Index()
        {
            return "This is the default ACTION";
        }
        
        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Create(categoryCreate model)
        {
           
           // CategoryRepository categoryRepository = new CategoryService();
            if(model.Name!=null)
            {
                //var category = new Category()
                //{
                //    Name = model.Name,
                //    Description = model.Description,
                //    Code = model.Code
                //};
                var category = _mapper.Map<Category>(model);

                var isAdded = _categoryService.Add(category);
                if(isAdded)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }

       
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryService.GetById((int)id);
            if(category==null)
            {
                return RedirectToAction("List");
            }
            var categoryEditVm = new CategoryEditVM()
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Description = category.Description

            };
            return View(categoryEditVm);

        }
        [HttpPost]
        public IActionResult Edit(CategoryEditVM model)
        {
            if(ModelState.IsValid)
            {
                var category = new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                    Code = model.Code,
                    Description = model.Description

                };

                bool isUpdated = _categoryService.Update(category);

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

            var category = _categoryService.GetById((int)id);
            if(category==null)
            {
                return RedirectToAction("List");
            }
            bool isRemoved = _categoryService.Remove(category);
            if(isRemoved)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        public IActionResult List(CategoryListVM model)

        {
            var categoryList = _categoryService.GetAll();

            //var item = _productService.GetById((int)id);
            var itemlist = _productService.GetAll();
            //weekly type
            // ViewBag.CategoryList = categoryList;

            var categoryListVm = new CategoryListVM()
            {
                Title = "Category Overview",
                Description = "Create,Update,Delet Categories",
                CategoryList = categoryList.ToList(),
                ItemList = itemlist.ToList()


            };

            //strongly type
            return View(categoryListVm);
        }

        public string CategoryListCreate(categoryCreate[] categories)
        {
            return "CategoryListCreate";
        }
    }
}
