using Microsoft.EntityFrameworkCore;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories;
using SMEcommerce.Repositories.Abstraction;
//using SMEcommerce.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EFcoreExamples.Repositories
{
    public class CategoryRepository:Repository<Category> ,ICategoryRepository
    {

        SMEcommerceDbContext _db;

        public CategoryRepository(SMEcommerceDbContext db) : base(db)
        {
            _db = db;
        }
        public override Category GetById(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == id);

        }



        public override ICollection<Category> GetAll()
        {
            return _db.Categories.Include(c => c.Items).ToList();
        }

        //public bool Add(Category category)
        //{
        //     db.Categories.Add(category);
        //    int SuccessCount = db.SaveChanges();
        //    return SuccessCount > 0;
        //}

        //public bool Update(Category category)
        //{
        //    db.Categories.Update(category);
        //    return db.SaveChanges()>0;
        //}

        //public bool Remove(Category category)
        //{
        //    db.Categories.Remove(category);
        //    return db.SaveChanges()>0;
        //}

      
    }
}
