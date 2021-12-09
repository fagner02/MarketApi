using System.Collections.Generic;
using System;

namespace market_api.Repositories {
    public interface IRepository<T> where T : class {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        bool Update(Guid id, T item);
        bool Delete(Guid id);
    }
}