namespace AngelSystem_Estacionamento.Core.TabelaPreco.Interface;

public interface ITabelaPrecoRepository
{
    IEnumerable<TabelaPrecoEntity> ObterTabelaPreco();
    TabelaPrecoEntity AtualizarValor(TabelaPrecoEntity entity);
}