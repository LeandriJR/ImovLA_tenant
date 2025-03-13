using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tenant.Domain
{
    [Table("tenant_log")]
    public class TenantLogEntity  : CoreEntity
    {
        [Key]
        [Column("tenant_log_id")]
        public Guid? TenantLogid { get; set; }
        
        [Column("tenant_id")]
        [ForeignKey("tenant_id")]
        public Guid? TenantId { get; set; }
        
        [Column("schema_name")]
        public string? SchemaName { get; set; }
        
        [Column("data_plano")]
        public DateTime? DataPlano { get; set; }
        
        [ForeignKey("plano_id")]
        [Column("plano_id")]
        public Guid? PlanoId { get; set; }
    }
}
