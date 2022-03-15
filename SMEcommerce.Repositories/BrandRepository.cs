using Microsoft.EntityFrameworkCore;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories;
using SMEcommerce.Repositories.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace EFcoreExamples.Repositories

{


    public class BrandRepository :Repository<Brand>,IBrandRepository
    {
        SMEcommerceDbContext _db;
         public BrandRepository(SMEcommerceDbContext db) :base(db)
         {
            //  db = new SMEcommerceDbContext();
            _db = db;

         }

        public override Brand GetById(int id)
        {
            return _db.Brands.FirstOrDefault(b => b.Id == id);
        }

        public override ICollection<Brand> GetAll()
        {
            return _db.Brands.Include(b => b.Items).ToList();
        }
        //public bool Add(Brand brand)
        //{
        //    db.Brands.Add(brand);
        //    return db.SaveChanges() > 0;
        //}

        //public bool Update(Brand brand)
        //{
        //    db.Brands.Update(brand);
        //    return db.SaveChanges() > 0;
        //}

        //public bool Remove(Brand brand)
        //{
        //    db.Brands.Remove(brand);
        //    return db.SaveChanges() > 0;
        //}

        //public override Brand GetById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
    
	
}
