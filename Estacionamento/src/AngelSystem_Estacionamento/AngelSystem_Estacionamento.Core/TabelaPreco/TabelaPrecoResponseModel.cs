using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.TabelaPreco;

public class TabelaPrecoResponseModel : Validator
{
    public TabelaPrecoEnum DescricaoHora { get; set; }
    public decimal Preco { get; set; }

    public override bool IsValid() => ValidationResult.IsValid;
}