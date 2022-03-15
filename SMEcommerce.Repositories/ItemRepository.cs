using Microsoft.EntityFrameworkCore;
using SMEcommerce.Databases.DbContexts;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories;
using SMEcommerce.Repositories.Abstraction;
using System.Collections.Generic;
using System.Linq;
//using SMEcommerce.Databases.DbContexts;
namespace EFcoreExamples.Repositories
{
    public class ItemRepository :Repository<Item>,IItemRepository
    {
        SMEcommerceDbContext _db;

        public ItemRepository(SMEcommerceDbContext db) : base(db)
        {
            //db = new SMEcommerceDbContext();
            _db = db;
        }

        public override Item GetById(int id)
        {
            return _db.Products.Include(c => c.Category)
                 .FirstOrDefault(e => e.Id == id);
        }

        public override ICollection<Item> GetAll()
        {
          //  return db.Products.Include(c => c.Id).ToList();
            return _db.Products.Include(i => i.Category).ToList();

        }

        //public bool Add(Item products)
        //{
        //    db.Products.Add(products);
        //    return db.SaveChanges()>0;
        //    //return SuccessCount > 0;
        //}

        //public bool Update(Item item)
        //{
        //    db.Products.Update(item);
        //    return db.SaveChanges()>0;
        //}
        //public bool Remove(Item item)
        //{
        //    db.Products.Remove(item);
        //    return db.SaveChanges()>0;
        //}

        //public override Item GetById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
