using System.Threading.Tasks;
using Audit_API.Data;
using Audit_API.Models;

namespace Audit_API._Repositories.Interface
{
    public interface IKindRepository : IAuditRepository<Kind>
    {
        Task<bool> CheckKindNameExists(string name);
    }
}