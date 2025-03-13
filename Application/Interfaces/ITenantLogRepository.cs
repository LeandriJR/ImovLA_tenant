using Tenant.Domain;

namespace Tenant.Application.Interfaces;

public interface ITenantLogRepository
{
        Task<TenantLogEntity> GetByIdAsync(string id);
        Task<TenantLogEntity> AddAsync(TenantLogEntity tenant);
        
}