using SMEcommerce.Repositories;
using SMEcommerce.Repositories.Abstraction;
using SMEcommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Services
{

   
    
    public abstract class Service<T> : IService<T> where T : class
    {
        IRepository<T> _repository;
        //private IItemRepository itemRepository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        //protected Service(IItemRepository itemRepository)
        //{
        //    this.itemRepository = itemRepository;
        //}

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
