namespace Tenant.Application.DTOs;

public class EnderecoDTO
{
    public Guid id { get; set; }
   
    public int? CEP { get; set; }
   
    public string? Logradouro { get; set; }
    
    public int? Numero { get; set; }
 
    public string? Complemento { get; set; }

    public string? Bairro { get; set; }
    
    public int? MunicipioId { get; set; }
}