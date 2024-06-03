using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.RegistroEstacionamento;

public class RegistroEstacionamentoResponseModel : Validator
{
    public int Id { get; private set; }
    public int ClienteId { get; private set; }
    public int VeiculoId { get; private set; }
    public DateTime DataEntrada { get; private set; }
    public DateTime? DataSaida { get; private set; }
    public TimeSpan TotalPermanencia { get; private set; }
    public decimal? Valor { get; private set; }

    public override bool IsValid() => ValidationResult.IsValid;
}