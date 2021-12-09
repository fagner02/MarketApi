using System;
using System.Collections.Generic;

namespace market_api.Services {
    interface IService<T> where T : class {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        T Create(T obj);

        bool Update(Guid id, T obj);

        bool Delete(Guid id);
    }
}