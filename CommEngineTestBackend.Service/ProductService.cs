using CommEngineTestBackend.DAL;
using CommEngineTestBackend.Model;
using CommEngineTestBackend.Repository;
using CommEngineTestBackend.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommEngineTestBackend.Service
{
    public class ProductService : IService<Product>
    {
        private readonly UnitOfWork _uow;

        public ProductService(AppDbContext context)
        {
            _uow = new UnitOfWork(context);
        }

        public List<Product> GetAll()
        {
            return _uow.ProductRepository.GetAll();
        }

        public void Save(Product employee)
        {
            _uow.ProductRepository.InsertOrUpdate(employee);
            _uow.ProductRepository.Save();
        }

        public void Delete(Guid id)
        {
            _uow.ProductRepository.Delete(id);
        }

        public Product Find(Guid id)
        {
            return _uow.ProductRepository.Find(id);
        }
    }
}
