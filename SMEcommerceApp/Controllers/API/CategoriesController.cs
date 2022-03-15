using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Services;
using SMEcommerce.Services.Abstraction;
using SMEcommerceApp.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Controllers.API
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]

        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "AdminUser")]
        [Authorize(Policy = "BangladeshiUser")]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                return NoContent();
            }

            var categoryResult = _mapper.Map<IList<CategoryResult>>(categories);

            return Ok(categoryResult);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id==null)
            {
                return BadRequest("Please Provide an Id");
            }
            var category = _categoryService.GetById((int)id);

            if(category==null)
            {
                return NotFound();
            }
            var categoryResult = _mapper.Map<CategoryResult>(category);

            return Ok(categoryResult);


        }
        [HttpPost]
        public IActionResult Post([FromBody]categoryCreate model)
        {
            if(ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                var isSuccess =_categoryService.Add(category);
                if(isSuccess)
                {
                    return Created($"api/categories/{category.Id}",category);
                }
            }

            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int? id,[FromBody] CategoryEditVM model)
        {
            if(id==null)
            {
                return BadRequest("Please provide id");
            }

            var category = _categoryService.GetById((int)id);

            if(category==null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _mapper.Map(model, category);

                bool isSuccess = _categoryService.Update(category);
                if(isSuccess)
                {
                    
                        return Ok(category);
                    
                }
            }
            return BadRequest(ModelState);
        }
    }
}
