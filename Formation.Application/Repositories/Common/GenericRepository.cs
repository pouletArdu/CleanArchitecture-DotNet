using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Application.Repositories.Common
{
    public interface GenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T book);
        Task<T> GetById(int id);
        Task<T> Update(T book);
        Task Delete(int id);
    }
}
