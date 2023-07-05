using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task Add(T model);
        Task Delete(int id);

        Task<bool> Save();

    }
}
