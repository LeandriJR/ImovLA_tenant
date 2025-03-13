using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant.Domain
{
    [Table("uf")]
    public class UfEntity : CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
       
        public string? UFCode { get; set; }
        public string? Nome { get; set; }
        public string? Regiao { get; set; }
    }
}
