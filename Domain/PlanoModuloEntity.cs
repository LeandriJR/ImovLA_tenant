using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Tenant.Domain
{
    [Table("plano_modulo")]
    public class PlanoModuloEntity : CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
       
        public Guid? PlanoId { get; set; }
        public Guid? ModuloId { get; set; }

        [ForeignKey("PlanoId")]
        public PlanoEntity? Plano { get; set; }

        [ForeignKey("ModuloId")]
        public ModuloEntity? Modulo { get; set; }
    }
}
