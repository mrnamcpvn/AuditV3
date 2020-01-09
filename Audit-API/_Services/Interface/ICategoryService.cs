using System.Threading.Tasks;
using Audit_API.DTOs;

namespace Audit_API._Services.Interface
{
    public interface ICategoryService : IAuditService<CategoryDto>
    {
        Task<bool> CheckKindNameExists(string name);

        Task<bool> ChangeStatus(object id);
    }
}