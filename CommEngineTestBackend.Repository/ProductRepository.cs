using CommEngineTestBackend.DAL;
using CommEngineTestBackend.Model;
using CommEngineTestBackend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommEngineTestBackend.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public void Delete(Guid id)
        {
            var itemToRemove = context.Products.SingleOrDefault(x => x.Id == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Products.Remove(itemToRemove);
                Save();
            }
        }

        public Product Find(Guid id)
        {
            return context.Products.Where(s => s.Id == id).FirstOrDefault();
        }

        public void InsertOrUpdate(Product Product)
        {
            if (Product.Id == Guid.Empty)
            {
                // New entity
                context.Products.Add(Product);
            }
            else
            {
                // Existing entity
                var s = context.Products.Where(c => c.Id == Product.Id).FirstOrDefault();
                s.Name = Product.Name;
                s.Category = Product.Category;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
