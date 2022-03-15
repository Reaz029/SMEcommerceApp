using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Services.Abstraction
{
   public interface IService<T> where T:class
    {

         T GetById(int id);
        ICollection<T> GetAll();
         bool Add(T entity);
         bool Remove(T entity);
        bool Update(T entity);


    }
}
