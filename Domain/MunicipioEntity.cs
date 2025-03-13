using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tenant.Domain
{
    [Table("municipio")]
    public class MunicipioEntity : CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
        public string? Nome { get; set; }

        [ForeignKey("uf_id")]
        public Guid? UFId { get; set; }
    }
}
