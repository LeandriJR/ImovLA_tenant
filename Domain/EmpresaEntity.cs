using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tenant.Domain
{
    [Table("empresa")]
    public class EmpresaEntity : CoreEntity
    {
        [Key]
        public Guid id { get; set; }
        
        [Column("nome_fantasia")]
        public string? NomeFantasia { get; set; }
        [Column("razao_social")]
        public string? RazaoSocial { get; set; }
        [Column("cnpj")]
        public string? CNPJ { get; set; }
        [Column("telefone")]
        public string? Telefone { get; set; }
        
        [ForeignKey("endereco_id")]
        [Column("endereco_id")]
        public Guid? EnderecoId { get; set; }
    }

}
