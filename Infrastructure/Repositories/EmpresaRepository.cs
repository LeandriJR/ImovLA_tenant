using Microsoft.EntityFrameworkCore;
using Tenant.Application.Interfaces;
using Tenant.Domain;

namespace Tenant.Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _context;

    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    // Método para buscar Tenant pelo ID
    public async Task<EmpresaEntity?> GetByIdAsync(string id)
    {
        return await _context.Empresas
            .FirstOrDefaultAsync(t => t.id == Guid.Parse(id));
    }
    
    public async Task<EmpresaEntity> AddAsync(EmpresaEntity empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return empresa;
    }

}