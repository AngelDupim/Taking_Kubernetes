namespace AngelSystem_Estacionamento.Core.TabelaPreco.Interface;

public interface ITabelaPrecoService
{
    ListaTabelaPrecoResponseModel ObterTabelaPreco();
    TabelaPrecoResponseModel AtualizarValor(TabelaPrecoRequestModel request);
    decimal? CalcularPrecoCobrar(TimeSpan totalHoraPermanencia);
}