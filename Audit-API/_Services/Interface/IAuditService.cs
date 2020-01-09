using System.Collections.Generic;
using System.Threading.Tasks;
using Audit_API.Helpers;

namespace Audit_API._Services.Interface
{
    public interface IAuditService<T> where T: class
    {
        Task<bool> Add(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(object id);

        Task<List<T>> GetAllAsync();

        Task<PagedList<T>> GetWithPaginations(PaginationParams param);

        T GetById(object id);

    }
}