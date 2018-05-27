using CommEngineTestBackend.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommEngineTestBackend.DAL
{
    public interface IDbInitializerService
    {
        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }
    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    // Add default Products

                    string[] categories = new[] { "Baby Food", "Grocery", "Drinks", "Electronics", "Beauty" };

                    if (!context.Products.Any())
                    {
                        for (int i = 0; i < categories.Count(); i++)
                        {
                            var p = new Product
                            {
                                Id = new Guid(),
                                Name = $"Product {i+1}",
                                CreateDate = DateTime.Now.AddDays(i),
                                Category = categories[i]
                            };
                            context.Products.Add(p);
                        }                        
                        context.SaveChanges();
                    }

                }
            }
        }

    }
}
