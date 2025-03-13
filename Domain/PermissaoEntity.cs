using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tenant.Domain
{
    [Table("permissao")]
    public class PermissaoEntity : CoreEntity
    {
        [Key]
        public Guid ID { get; set; }
        public string? NomePermissao { get; set; }
        public string? Descricao { get; set; }
        public Guid? ModuloId { get; set; }
        [ForeignKey("ModuloId")]
        public ModuloEntity? Modulo { get; set; }
    }
}

