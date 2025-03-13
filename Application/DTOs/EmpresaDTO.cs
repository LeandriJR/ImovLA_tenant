using Tenant.Domain;

namespace Tenant.Application.DTOs
{

    public class EmpresaDTO
    {
        public Guid id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public Guid? EnderecoId { get; set; }
    }

}