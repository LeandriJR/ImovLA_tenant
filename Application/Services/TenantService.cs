using Tenant.Application.DTOs;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Application.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        
        // Método para buscar Tenant
        public async Task<TenantDTO> GetTenantByIdAsync(string id)
        {
             var tenantEntity = await _tenantRepository.GetByIdAsync(id);
            if (tenantEntity == null)
                return null;

            // Mapeando TenantEntity para TenantDTO
            return new TenantDTO
            {
                id = tenantEntity.id,
                SchemaName = tenantEntity.SchemaName,
                PlanoId = tenantEntity.PlanoId,
                Status = tenantEntity.Status,
                DataPlano = tenantEntity.DataPlano
            };
        }

        public async Task<TenantDTO> AddTenantAsync(TenantDTO tenantDto)
        {
            var tenantEntity = new TenantEntity
            {
                id = tenantDto.id,
                SchemaName = tenantDto.SchemaName,
                PlanoId = tenantDto.PlanoId,
                Status = tenantDto.Status,
                DataPlano = tenantDto.DataPlano
            };

            var newTenant = await _tenantRepository.AddAsync(tenantEntity);
            
            // Mapeando TenantEntity de volta para TenantDTO
            return new TenantDTO
            {
                id = newTenant.id,
                SchemaName = newTenant.SchemaName,
                PlanoId = newTenant.PlanoId,
                Status = newTenant.Status,
                DataPlano = newTenant.DataPlano
            };
        }
    }
}
