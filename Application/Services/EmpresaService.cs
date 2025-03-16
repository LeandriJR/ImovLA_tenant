using Tenant.Application.DTOs;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Application.Services{

public class EmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly ITenantRepository _tenantRepository;
    public EmpresaService(IEmpresaRepository empresaRepository, ITenantRepository tenantRepository)
    {
        _empresaRepository = empresaRepository;
        _tenantRepository = tenantRepository;
    }
    
    public async Task<EmpresaValidaDTO> GetEmpresaByIdAsync(string id)
    {
        var empresaEntity = await _empresaRepository.GetByIdAsync(id);
        if (empresaEntity == null)
            return null;
        
        if (empresaEntity.TenantId == null)
            return null;

        var tenantEntity = await _tenantRepository.GetByIdAsync(empresaEntity.TenantId.ToString());
        
        return new EmpresaValidaDTO
        {
            id = empresaEntity.id,
            NomeFantasia = empresaEntity.NomeFantasia,  
            CNPJ = empresaEntity.CNPJ,
            DataPlano = tenantEntity.DataPlano,
            PlanoId = tenantEntity.PlanoId
        };
    }
    
    public async Task<EmpresaDTO> GetEmpresaValidaByIdAsync(string id)
    {
        var empresaEntity = await _empresaRepository.GetByIdAsync(id);
        if (empresaEntity == null)
            return null;
        
        // Mapeando TenantEntity para TenantDTO
        return new EmpresaDTO
        {
            id = empresaEntity.id,
            NomeFantasia = empresaEntity.NomeFantasia,  
            RazaoSocial = empresaEntity.RazaoSocial,
            CNPJ = empresaEntity.CNPJ,
            Telefone = empresaEntity.Telefone,
            EnderecoId = empresaEntity.EnderecoId,
        };
    }
    
    
    public async Task<EmpresaDTO> AddTenantAsync(EmpresaDTO empresaDTO)
    
    {
        var empresaEntity = new EmpresaEntity
        {
            id = empresaDTO.id,
            NomeFantasia = empresaDTO.NomeFantasia,  
            RazaoSocial = empresaDTO.RazaoSocial,
            CNPJ = empresaDTO.CNPJ,
            Telefone = empresaDTO.Telefone,
            EnderecoId = empresaDTO.EnderecoId,
        };

        var newEmpresa = await _empresaRepository.AddAsync(empresaEntity);
        
        // Mapeando TenantEntity de volta para TenantDTO
        return new EmpresaDTO
        {
            id = newEmpresa.id,
            NomeFantasia = newEmpresa.NomeFantasia,  
            RazaoSocial = newEmpresa.RazaoSocial,
            CNPJ = newEmpresa.CNPJ,
            Telefone = newEmpresa.Telefone,
            EnderecoId = newEmpresa.EnderecoId,
        };
    }
}

}