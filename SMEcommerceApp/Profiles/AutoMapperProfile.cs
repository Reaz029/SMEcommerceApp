using AutoMapper;
using SMEcommerce.Models.EntityModels;
using SMEcommerceApp.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEcommerceApp.Profiles
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Category, categoryCreate>();
            CreateMap<Category, CategoryEditVM>();
            CreateMap<categoryCreate, Category>();
            CreateMap<CategoryEditVM, Category>();
            CreateMap<Category, CategoryResult>();
        }
    }
}
