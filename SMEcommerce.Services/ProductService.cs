using SMEcommerce.Models.EntityModels;
using SMEcommerce.Repositories.Abstraction;
using SMEcommerce.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMEcommerce.Services
{
   public class ProductService:Service<Item>, IProductService
    {
        IItemRepository _ProductRepository;

        public ProductService(IItemRepository itemRepository) : base(itemRepository)
        {
            _ProductRepository = itemRepository;

        }

        //public Item GetById(int id)
        //{
        //    return _ProductRepository.GetById(id);
        //}

        //public ICollection<Item> GetAll()
        //{
        //    return _ProductRepository.GetAll();
        //}
        //public bool Add(Item Product)
        //{
        //    return _ProductRepository.Add(Product);
        //}
        //public bool Remove(Item Product)
        //{
        //    return _ProductRepository.Remove(Product);
        //}

        //public bool Update(Item product)
        //{
        //   return _ProductRepository.Update(product);
        //}



    }
}
