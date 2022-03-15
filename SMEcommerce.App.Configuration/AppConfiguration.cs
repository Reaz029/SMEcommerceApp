using EFcoreExamples.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Repositories.Abstraction;
using SMEcommerce.Services;
using SMEcommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.App.Configurations
{
   public class AppConfiguration
    {

        public static void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<SMEcommerceDbContext>(c => c.UseSqlServer(@"Server=(local);Database=SMECommerceDB; Integrated Security=true"));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<SMEcommerce.Services.Abstraction.IProductService, ProductService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IItemRepository, ItemRepository>();

        }

    }
}
