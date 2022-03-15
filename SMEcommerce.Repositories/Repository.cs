using Microsoft.EntityFrameworkCore;
using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMEcommerce.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T:class
    {
        DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }

       private DbSet<T> table { get
            {
                return _db.Set<T>();
            } }


        public virtual bool Add(T entity)
        {
            _db.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            
            return table.ToList();
        }

        public abstract T GetById(int id);
        

        public bool Remove(T entity)
        {
            _db.Remove(entity);
            return _db.SaveChanges()>0;
        }

        public bool Update(T entity)
        {
            _db.Update(entity);
            return _db.SaveChanges() > 0;
        }
    }
}
