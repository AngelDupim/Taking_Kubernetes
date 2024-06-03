namespace AngelSystem_Estacionamento.Core.TabelaPreco;

public class TabelaPrecoEntity
{
    public string DescricaoHora { get; private set; }
    public decimal Preco { get; private set; }

    public TabelaPrecoEntity(string descricaoHora, decimal preco)
    {
        DescricaoHora = descricaoHora;
        Preco = preco;
    }
}