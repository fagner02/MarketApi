using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace market_api.Services {
    public interface IService<Dto, DtoCreate> {
        Task<IEnumerable<Dto>> GetAll();

        Task<Dto> Get(Guid id);

        Task<DtoCreate> Create(DtoCreate obj);

        Task<bool> Update(Guid id, Dto obj);

        Task<bool> Delete(Guid id);
    }
}