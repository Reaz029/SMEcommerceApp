using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Repositories.Abstraction
{
   public interface IRepository<T> where T: class
    {

        public T GetById(int id);
        public ICollection<T> GetAll();
        public bool Add(T entity);
        public bool Remove(T entity);
        public bool Update(T entity);
    }
}
