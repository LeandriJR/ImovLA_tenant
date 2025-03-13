using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tenant.Domain
{
    [Table("endereco")]
    public class EnderecoEntity : CoreEntity
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }
        [Column("cep")]
        public int? CEP { get; set; }
        [Column("logradouro")]
        public string? Logradouro { get; set; }
        [Column("numero")]
        public int? Numero { get; set; }
        [Column("complemento")]
        public string? Complemento { get; set; }
        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("municipio_id")]
        [ForeignKey("municipio_id")]
        public int? MunicipioId { get; set; }
    }
}
