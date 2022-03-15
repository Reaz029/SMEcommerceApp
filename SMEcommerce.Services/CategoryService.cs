using EFcoreExamples.Repositories;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories.Abstraction;
using SMEcommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Services
{

   public class CategoryService: Service<Category>,ICategoryService
    {


     
            ICategoryRepository _categoryRepository;

            public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
            {
            _categoryRepository = categoryRepository;
            }

            //public ICollection<Category> GetAll()
            //{
            //    return _categoryRepository.GetAll();
            //}

            //public Category GetById(int id)
            //{
            //    return _categoryRepository.GetById(id);
            //}

            //public bool Add(Category category)
            //{

            //    // logic for category add 
            //    if (string.IsNullOrEmpty(category.Name))
            //    {
            //        return false;
            //    }
            //    // .... 

            //    return _categoryRepository.Add(category);


            //}

            //public bool Update(Category category)
            //{
            //    return _categoryRepository.Update(category);
            //}

            //public bool Remove(Category category)
            //{
            //    return _categoryRepository.Remove(category);
            //}
        }

    }

