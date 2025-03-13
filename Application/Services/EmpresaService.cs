using Tenant.Application.DTOs;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Application.Services{

public class EmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaService(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }
    
    public async Task<EmpresaDTO> GetEmpresaByIdAsync(string id)
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