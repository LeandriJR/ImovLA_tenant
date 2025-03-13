using Microsoft.EntityFrameworkCore;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Infrastructure.Repositories
{
    public class TenantLogRepository : ITenantLogRepository
    {
        private readonly AppDbContext _context;

        public TenantLogRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método para buscar Tenant pelo ID
        public async Task<TenantLogEntity?> GetByIdAsync(string id)
        {
            return await _context.TenantLogs
                .FirstOrDefaultAsync(t => t.TenantLogid == Guid.Parse(id));
        }

        // Método para adicionar um novo Tenant
        public async Task<TenantLogEntity> AddAsync(TenantLogEntity tenantLog)
        {
            _context.TenantLogs.Add(tenantLog);
            await _context.SaveChangesAsync();
            return tenantLog;
        }
    }
}