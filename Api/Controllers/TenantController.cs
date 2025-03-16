using Tenant.Application.Services;
using Tenant.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly TenantService _tenantService;

        public TenantController(TenantService tenantService)
        {
            _tenantService = tenantService;
        }

        // GET api/tenant/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TenantDTO>> GetTenant(string id)
        {
            var tenant = await _tenantService.GetTenantByIdAsync(id);
            if (tenant == null)
                return NotFound();

            return Ok(tenant);
        }

        [HttpPost]
        public async Task<ActionResult<TenantDTO>> CreateTenant([FromBody] TenantDTO tenantDto)
        {
            if (tenantDto == null)
                return BadRequest("Invalid tenant data");

            var newTenant = await _tenantService.AddTenantAsync(tenantDto);
            return CreatedAtAction(nameof(GetTenant), new { id = newTenant.id }, newTenant);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<TenantDTO>> UpdateTenant([FromBody] TenantDTO tenantDto)
        {
            if (tenantDto == null)
                return BadRequest("Invalid tenant data");

            var newTenant = await _tenantService.AddTenantAsync(tenantDto);
            return CreatedAtAction(nameof(GetTenant), new { id = newTenant.id }, newTenant);
        }
        
        [HttpPut("{id}/status")]
        public async Task<ActionResult<TenantDTO>> DesativarTenant(string id)
        {
            var tenant = await _tenantService.InativarTenantAsync(id);
            return Ok();
        }
    }
}
