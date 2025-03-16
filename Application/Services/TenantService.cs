using Tenant.Application.DTOs;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Application.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ITenantLogRepository _tenantLogRepository;
     
        public TenantService(ITenantRepository tenantRepository, ITenantLogRepository tenantLogRepository)
        {
            _tenantRepository = tenantRepository;
            _tenantLogRepository = tenantLogRepository;
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
            Guid newID = Guid.NewGuid();
            var tenantEntity = new TenantEntity
            {
                id = newID,
                SchemaName = tenantDto.SchemaName,
                PlanoId = tenantDto.PlanoId,
                Status = tenantDto.Status,
                DataPlano = tenantDto.DataPlano
            };

            var newTenant = await _tenantRepository.AddAsync(tenantEntity);
            
            await _tenantLogRepository.AddAsync(new TenantLogEntity
            {
                TenantLogid = Guid.NewGuid(),
                TenantId = newID,
                SchemaName = newTenant.SchemaName,
                PlanoId = newTenant.PlanoId,
                Status = newTenant.Status,
                InsertDate = DateTime.UtcNow,
                DataPlano = newTenant.DataPlano
                
            });
            return new TenantDTO
            {
                id = newTenant.id,
                SchemaName = newTenant.SchemaName,
                PlanoId = newTenant.PlanoId,
                Status = newTenant.Status,
                DataPlano = newTenant.DataPlano
            };
        }

        public async Task<TenantDTO> InativarTenantAsync(string id)
        {
            var tenantEntity = await _tenantRepository.GetByIdAsync(id);

            if (tenantEntity == null)
                return null; // Pode lançar uma exceção ou retornar NotFound

            // Atualizar apenas o campo necessário
            tenantEntity.Status = false;
            tenantEntity.UpdateDate = DateTime.UtcNow; // Atualiza a data da última modificação

            // Salvar no banco de dados
            await _tenantRepository.UpdateAsync(tenantEntity);

            // Retornar a versão atualizada como DTO
            return new TenantDTO
            {
                id = tenantEntity.id,
                SchemaName = tenantEntity.SchemaName,
                PlanoId = tenantEntity.PlanoId,
                Status = tenantEntity.Status,
                DataPlano = tenantEntity.DataPlano
            };
        }
        
    }
}
