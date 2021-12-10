using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace market_api.Services {
    public interface IService<T, T1> {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Guid id);

        Task<T1> Create(T1 obj);

        Task<bool> Update(Guid id, T obj);

        Task<bool> Delete(Guid id);
    }
}