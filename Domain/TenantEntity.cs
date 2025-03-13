using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tenant.Domain
{
    [Table("tenant")]
    public class TenantEntity : CoreEntity
    {
        [Key]
        public Guid? id { get; set; }
        
        [Column("schema_name")]
        public string? SchemaName { get; set; }
        
        [Column("data_plano")]
        public DateTime? DataPlano { get; set; }
        
        [ForeignKey("plano_id")]
        [Column("plano_id")]
        public Guid? PlanoId { get; set; }
    }

}
