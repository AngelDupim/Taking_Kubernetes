using AngelSystem_Estacionamento.Core.RegistroEstacionamento;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;
using AngelSystem_Estacionamento.Infrastructure.Context;
using System.Text;

namespace AngelSystem_Estacionamento.Infrastructure.Persistence
{
    public class RegistroEstacionamentoRepository : SqlServerContext<RegistroEstacionamentoEntity>, IRegistroEstacionamentoRepository
    {
        public RegistroEstacionamentoEntity Adicionar(RegistroEstacionamentoEntity entity)
        {
            var sql = @"INSERT [RegistroEstacionamento]
                               (     [ClienteId]
                                    ,[VeiculoId]
                                    ,[DataEntrada]
                                    ,[DataSaida]
                                    ,[TotalPermanencia]
                                    ,[Valor]
                               )
                        OUTPUT       INSERTED.[Id]
                                    ,INSERTED.[ClienteId]
                                    ,INSERTED.[VeiculoId]
                                    ,INSERTED.[DataEntrada]
                                    ,INSERTED.[DataSaida]
                                    ,INSERTED.[TotalPermanencia]
                                    ,INSERTED.[Valor]
                                     
                        VALUES (     @ClienteId
                                    ,@VeiculoId
                                    ,@DataEntrada
                                    ,@DataSaida
                                    ,@TotalPermanencia
                                    ,@Valor
                               )";

            return QueryFirstOrDefault<RegistroEstacionamentoEntity>(sql,
                new
                {
                    entity.ClienteId,
                    entity.VeiculoId,
                    entity.DataEntrada,
                    entity.DataSaida,
                    entity.TotalPermanencia,
                    entity.Valor
                }
            );
        }

        public RegistroEstacionamentoEntity AtualizarValoresSaida(RegistroEstacionamentoEntity entity)
        {
            var sql = @"UPDATE [RegistroEstacionamento] SET
                                 [DataSaida] = @DataSaida
                                ,[TotalPermanencia] = @TotalPermanencia
                                ,[Valor] = @Valor
                        OUTPUT       INSERTED.[Id]
                                    ,INSERTED.[ClienteId]
                                    ,INSERTED.[VeiculoId]
                                    ,INSERTED.[DataEntrada]
                                    ,INSERTED.[DataSaida]
                                    ,INSERTED.[TotalPermanencia]
                                    ,INSERTED.[Valor]
                        WHERE [Id] = @Id ";

            return QueryFirstOrDefault<RegistroEstacionamentoEntity>(sql, entity);
        }

        public IEnumerable<RegistroEstacionamentoEntity> ObterPorClienteIdVeiculoId(int? clienteId, int? veiculoId)
        {
            var sql = new StringBuilder();

            sql.Append(@"SELECT      [Id]
                                    ,[ClienteId]
                                    ,[VeiculoId]
                                    ,[DataEntrada]
                                    ,[DataSaida]
                                    ,[TotalPermanencia]
                                    ,[Valor]
                        FROM [RegistroEstacionamento]
                        WHERE 1=1");

            if (clienteId.HasValue) sql.AppendLine("AND [ClienteId] = @clienteId");
            if (clienteId.HasValue) sql.AppendLine("AND [VeiculoId] = @veiculoId");

            return Query<RegistroEstacionamentoEntity>(sql.ToString(), new { clienteId, veiculoId });
        }
    }
}