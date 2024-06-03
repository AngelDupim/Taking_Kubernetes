using AngelSystem_Estacionamento.Core.TabelaPreco;
using AngelSystem_Estacionamento.Core.TabelaPreco.Interface;
using AngelSystem_Estacionamento.Infrastructure.Context;

namespace AngelSystem_Estacionamento.Infrastructure.Persistence;

public class TabelaPrecoRepository : SqlServerContext<TabelaPrecoRepository>, ITabelaPrecoRepository
{
    public IEnumerable<TabelaPrecoEntity> ObterTabelaPreco() 
    {
        var sql = @"SELECT   [DescricaoHora]
                                ,[Preco]
                       FROM [TabelaPreco] ";

        return Query<TabelaPrecoEntity>(sql);
    }


    public TabelaPrecoEntity AtualizarValor(TabelaPrecoEntity entity) 
    {
        var sql = @"UPDATE [TabelaPreco] SET 
                             [Preco] = @Preco 
                       WHERE [DescricaoHora] = @DescricaoHora ";

        return QueryFirstOrDefault<TabelaPrecoEntity>(sql, new { entity.Preco, entity.DescricaoHora });
    }
}