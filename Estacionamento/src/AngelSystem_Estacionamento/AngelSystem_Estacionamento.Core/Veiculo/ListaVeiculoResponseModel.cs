using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.Veiculo;

public class ListaVeiculoResponseModel : Validator
{
    public IEnumerable<VeiculoResponseModel> Veiculos { get; set; }

    public override bool IsValid() => ValidationResult.IsValid;
}