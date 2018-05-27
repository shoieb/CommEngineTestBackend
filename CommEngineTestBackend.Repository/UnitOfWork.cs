using CommEngineTestBackend.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommEngineTestBackend.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public ProductRepository _productRepository;
        public ProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository(context);
                }
                return _productRepository;
            }
        }
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
