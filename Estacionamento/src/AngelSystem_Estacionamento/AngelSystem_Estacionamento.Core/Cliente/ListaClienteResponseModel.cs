using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.Cliente;

public class ListaClienteResponseModel : Validator
{
    public IEnumerable<ClienteResponseModel> ListaCliente { get; set; }

    public override bool IsValid() => ValidationResult.IsValid;
}