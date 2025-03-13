using Tenant.Domain;
using Tenant.Infrastructure.Repositories;
namespace Tenant.Application.Interfaces;

public interface ITenantRepository
{
    Task<TenantEntity> GetByIdAsync(string id);
    Task<TenantEntity> AddAsync(TenantEntity tenant);
}
