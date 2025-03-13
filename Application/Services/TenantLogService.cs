using Tenant.Application.DTOs;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Application.Services
{
    public class TenantLogService
    {
        private readonly ITenantLogRepository _tenantLogRepository;

        public TenantLogService(ITenantLogRepository tenantLogRepository)
        {
            _tenantLogRepository = tenantLogRepository;
        }

        // Método para buscar Tenant
        public async Task<TenantDTO> GetTenantByIdAsync(string id)
        {
            var tenantLogEntity = await _tenantLogRepository.GetByIdAsync(id);
            if (tenantLogEntity == null)
                return null;

            // Mapeando TenantEntity para TenantDTO
            return new TenantDTO
            {
                id = tenantLogEntity.TenantLogid,
                SchemaName = tenantLogEntity.SchemaName,
                PlanoId = tenantLogEntity.PlanoId,
                Status = tenantLogEntity.Status,
                DataPlano = tenantLogEntity.DataPlano
            };
        }

        public async Task<TenantDTO> AddTenantAsync(TenantDTO tenantDto)
        {
            var tenantLogEntity = new TenantLogEntity
            {
                TenantLogid = tenantDto.id,
                SchemaName = tenantDto.SchemaName,
                PlanoId = tenantDto.PlanoId,
                Status = tenantDto.Status,
                DataPlano = tenantDto.DataPlano
            };

            var newTenant = await _tenantLogRepository.AddAsync(tenantLogEntity);
            
            return new TenantDTO
            {
                id = newTenant.TenantLogid,
                SchemaName = newTenant.SchemaName,
                PlanoId = newTenant.PlanoId,
                Status = newTenant.Status,
                DataPlano = newTenant.DataPlano
            };
        }
    }
}