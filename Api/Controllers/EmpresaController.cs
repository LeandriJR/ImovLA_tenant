using Microsoft.AspNetCore.Mvc;
using Tenant.Application.DTOs;
using Tenant.Application.Services;

namespace Tenant.Api.Controllers;

[Route("api/empresa/")]
public class EmpresaController : ControllerBase
{
    private readonly EmpresaService _empresaService;

    public EmpresaController(EmpresaService empresaService)
    {
        _empresaService = empresaService;
    }
        
    [HttpGet("{id}")]
    public async Task<ActionResult<EmpresaValidaDTO>> GetEmpresa(string id)
    {
        var empresa_valida = await _empresaService.GetEmpresaByIdAsync(id);
        if (empresa_valida == null)
            return NotFound(new { message = "Empresa não encontrada." });

        return Ok(empresa_valida);
    }
    [HttpGet("{id}/validarEmpresa")]
    public async Task<ActionResult<EmpresaDTO>> GetEmpresaValida(string id)
    {
        var tenant = await _empresaService.GetEmpresaValidaByIdAsync(id);
        if (tenant == null)
            return NotFound(new { message = "Empresa não encontrada." });

        return Ok(tenant);
    }
    [HttpPost]
    public async Task<ActionResult<EmpresaDTO>> CreateTenant([FromBody] EmpresaDTO empresaDTO)
    {
        if (empresaDTO == null)
            return BadRequest("Invalid tenant data");

        var newTenant = await _empresaService.AddTenantAsync(empresaDTO);
        return CreatedAtAction(nameof(GetEmpresa), new { id = newTenant.id }, newTenant);
    }
}