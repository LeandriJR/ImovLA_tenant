
using Microsoft.EntityFrameworkCore;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método para buscar Tenant pelo ID
        public async Task<TenantEntity?> GetByIdAsync(string id)
        {
            return await _context.Tenants
                .FirstOrDefaultAsync(t => t.id == Guid.Parse(id));
        }

        // Método para adicionar um novo Tenant
        public async Task<TenantEntity> AddAsync(TenantEntity tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }
    }
}
