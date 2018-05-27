using System;
using System.Collections.Generic;
using System.Text;

namespace CommEngineTestBackend.Service.Interface
{
    public interface IService<T> where T : class
    {
        T Find(Guid id);
        List<T> GetAll();
        void Save(T t);
        void Delete(Guid id);
    }
}
