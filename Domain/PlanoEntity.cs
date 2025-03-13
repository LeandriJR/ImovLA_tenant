using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant.Domain
{
    [Table("plano")]
    public class PlanoEntity
    {
        [Key]
        [Column("id")]
        public Guid ID { get; set; }
        [Column("status")]
        public bool? Status { get; set; }
        [Column("insert_date")]
        public DateTime? InsertDate { get; set; }
        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }
        [Column("insert_user")]
        public Guid? InsertUser { get; set; }
        [Column("update_user")]
        public Guid? UpdateUser { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("limite_imoveis")]
        public int? LimiteImoveis { get; set; }
        [Column("limite_usuarios")]
        public int? LimiteUsuarios { get; set; }
        [Column("valor")]
        public decimal? Valor { get; set; }
    }
}
