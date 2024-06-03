namespace AngelSystem_Estacionamento.Core.Cliente;

public class ClienteRequestModel
{
    public string NomeCompleto { get; set; }
    public string CpfCnpj { get; set; }
    public string TipoPessoa { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}