using System.Collections.Generic;
using System.Threading.Tasks;
using Audit_API.Data;
using Audit_API.Models;

namespace Audit_API._Repositories.Interface
{
    public interface ICategoryRepository : IAuditRepository<Category>
    {
        Task<bool> CheckCategoryNameExists(string name);

        List<Category> GetByKindId(int id);

    }
}