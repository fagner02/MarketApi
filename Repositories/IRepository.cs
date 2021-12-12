using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace market_api.Repositories {
    public interface IRepository<T, T1> {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T item);
        Task<bool> Update(Guid id, T item);
        Task<bool> Delete(Guid id);
    }
}