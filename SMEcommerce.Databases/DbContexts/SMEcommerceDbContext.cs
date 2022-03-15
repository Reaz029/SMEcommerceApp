using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Models.EntityModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMEcommerce.Databases.DbContexts
{
    public class SMEcommerceDbContext : IdentityDbContext<AppUser,AppRole,int>
    {

        public SMEcommerceDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Brand> Brands { get; set; }
        // public object Brand { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Server=(local);Database=SMecommerceDB; Integrated Security =true";
            //optionsBuilder.UseSqlServer(connectionString)
            //    ;

            //. UseLazyLoadingProxies()

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AppUsers");

            });


                }

    }
}
