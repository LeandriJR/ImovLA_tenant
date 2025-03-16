namespace Tenant.Application.DTOs;

public class EmpresaValidaDTO
{
    public Guid id { get; set; }
    public string? NomeFantasia { get; set; }
    public string? CNPJ { get; set; }
    public Guid? PlanoId { get; set; }
    public DateTime? DataPlano { get; set; }
}