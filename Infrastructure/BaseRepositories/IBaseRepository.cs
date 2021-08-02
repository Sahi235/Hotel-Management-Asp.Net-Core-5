using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.BaseRepositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
    }
}
