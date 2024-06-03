using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.TabelaPreco;

public class ListaTabelaPrecoResponseModel : Validator
{
    public required IEnumerable<TabelaPrecoResponseModel> TabelaPrecos { get; set; } 
    public override bool IsValid() => ValidationResult.IsValid;
}