using Tenant.Domain;

namespace Tenant.Application.DTOs
{
    public class TenantDTO
    {
        public Guid? id { get; set; }
        public string? SchemaName { get; set; }
        public Guid? PlanoId { get; set; }
        public bool? Status { get; set; }
        public DateTime? DataPlano { get; set; }
    }
}
