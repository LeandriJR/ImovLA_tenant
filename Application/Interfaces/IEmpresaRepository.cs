using Tenant.Domain;

namespace Tenant.Application.Interfaces;

public interface IEmpresaRepository
{
    Task<EmpresaEntity> GetByIdAsync(string id);
    Task<EmpresaEntity> AddAsync(EmpresaEntity empresa);
}