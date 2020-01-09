using System.Threading.Tasks;
using Audit_API._Repositories.Interface;
using Audit_API.Data;
using Audit_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Audit_API._Repositories.Repositories
{
    public class KindRepository : AuditRepository<Kind>, IKindRepository
    {
        private readonly DataContext _context;
        public KindRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckKindNameExists(string name)
        {
            if (await _context.Kind.AnyAsync(x => x.name == name))
                return true;
            return false;
        }
    }
}