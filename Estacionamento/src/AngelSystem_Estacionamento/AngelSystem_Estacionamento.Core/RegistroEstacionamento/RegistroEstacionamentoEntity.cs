namespace AngelSystem_Estacionamento.Core.RegistroEstacionamento;

public class RegistroEstacionamentoEntity
{
    public int Id { get; private set; }
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public DateTime DataEntrada { get; private set; }
    public DateTime? DataSaida { get; private set; }
    public TimeSpan? TotalPermanencia { get; private set; }
    public decimal? Valor { get; private set; }

    public void AdicionarRegistroEstacionamento()
    {
        DataEntrada = DateTime.Now;
    }

    public void AtualizarRegistroEstacionamento(DateTime dataSaida, TimeSpan totalPermanencia, decimal valor)
    {
        DataSaida = dataSaida;
        TotalPermanencia = totalPermanencia;
        Valor = valor;
    }
}