using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.Cliente;

public class ClienteResponseModel : Validator
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CpfCnpj { get; set; }
    public string TipoPessoa { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public override bool IsValid() => ValidationResult.IsValid;
}