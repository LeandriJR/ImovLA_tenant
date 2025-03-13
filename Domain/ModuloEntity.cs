using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant.Domain
{
    [Table("modulo")]
    public class ModuloEntity : CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
        
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? ValorSoma { get; set; }
    }
}
