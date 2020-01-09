using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audit_API._Repositories.Interface;
using Audit_API.Data;
using Audit_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Audit_API._Repositories.Repositories
{
    public class CategoryRepository : AuditRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckCategoryNameExists(string name)
        {
            return await _context.Category.AnyAsync(x => x.name == name);
        }

        public List<Category> GetByKindId(int id)
        {
            return _context.Category.Where(x => x.KindId == id).ToList();
        }
    }
}