using DataAccessLayer.Repositories;
using DataLayer.Contexts;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataLayer.Repository
{
    public class FormRepository : Repository<Form>, IFormRepository
    {
        public FormRepository(InvoiceDbContext context) : base(context) { }

        public async Task<IEnumerable<Form>> GetAllFormsAsync()
        {
            return await AsQueryable()

                .Include(f => f.RequestRoleForms)
                //.Include(f => f.GroupRoleAuths)
                .ToListAsync();
        }

        public async Task<Form?> GetFormByIdAsync(int id)
        {
            return await AsQueryable()
                .Include(f => f.RequestRoleForms)
                //.Include(f => f.GroupRoleAuths)
                .FirstOrDefaultAsync(f => f.FormId == id);
        }
    }



}
