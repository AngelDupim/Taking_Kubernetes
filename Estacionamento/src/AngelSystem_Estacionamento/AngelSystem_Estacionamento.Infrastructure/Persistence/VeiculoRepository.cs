using AngelSystem_Estacionamento.Core.Veiculo;
using AngelSystem_Estacionamento.Core.Veiculo.Interface;
using AngelSystem_Estacionamento.Infrastructure.Context;
using System.Text;

namespace AngelSystem_Estacionamento.Infrastructure.Persistence
{
    public class VeiculoRepository : SqlServerContext<VeiculoEntity>, IVeiculoRepository
    {
        public VeiculoEntity Adicionar(VeiculoEntity entity)
        {
            var sql = @"INSERT INTO [Veiculo] 
                                (   [Marca]
                                   ,[Modelo]
                                   ,[Ano]
                                   ,[Placa]
                                   ,[Cidade]
                                   ,[Uf]
                                   ,[ClienteId]
                                   ,[Ativo]
                                   ,[DataCadastro]
                                   ,[DataAtualizacao]
                                )
                        OUTPUT
                                    INSERTED.[Id]
                                   ,INSERTED.[Marca]
                                   ,INSERTED.[Modelo]
                                   ,INSERTED.[Ano]
                                   ,INSERTED.[Placa]
                                   ,INSERTED.[Cidade]
                                   ,INSERTED.[Uf]
                                   ,INSERTED.[ClienteId]
                                   ,INSERTED.[Ativo]
                                   ,INSERTED.[DataCadastro]
                                   ,INSERTED.[DataAtualizacao]
                        VALUES 
                                (   @Marca
                                   ,@Modelo
                                   ,@Ano
                                   ,@Placa
                                   ,@Cidade
                                   ,@Uf
                                   ,@ClienteId
                                   ,@Ativo
                                   ,@DataCadastro
                                   ,@DataAtualizacao                            
                                )";

            return QueryFirstOrDefault<VeiculoEntity>(sql, entity);
        }

        public VeiculoEntity Atualizar(VeiculoEntity entity)
        {
            var sql = @"UPDATE [Veiculo] SET
                                 [Placa] = @Placa
                                ,[ClienteId] = @ClienteId
                                ,[Ativo] = @Ativo
                                ,[DataCadastro] = @DataCadastro
                                ,[DataAtualizacao] = @DataAtualizacao
                        OUTPUT
                                 INSERTED.[Id]
                                ,INSERTED.[Marca]
                                ,INSERTED.[Modelo]
                                ,INSERTED.[Ano]
                                ,INSERTED.[Placa]
                                ,INSERTED.[Cidade]
                                ,INSERTED.[Uf]
                                ,INSERTED.[ClienteId]
                                ,INSERTED.[Ativo]
                                ,INSERTED.[DataCadastro]
                                ,INSERTED.[DataAtualizacao]
                        WHERE [Id] = @Id";

            return QueryFirstOrDefault<VeiculoEntity>(sql, entity);
        }

        public VeiculoEntity Excluir(VeiculoEntity entity)
        {
            var sql = @"UPDATE [Veiculo] SET 
                                 [Ativo] = @Ativo
                                ,[DataAtualizacao] = @DataAtualizacao
                        OUTPUT
                                 INSERTED.[Id]
                                ,INSERTED.[Marca]
                                ,INSERTED.[Modelo]
                                ,INSERTED.[Ano]
                                ,INSERTED.[Placa]
                                ,INSERTED.[Cidade]
                                ,INSERTED.[Uf]
                                ,INSERTED.[ClienteId]
                                ,INSERTED.[Ativo]
                                ,INSERTED.[DataCadastro]
                                ,INSERTED.[DataAtualizacao]                        
                        WHERE [Id] = @id";

            return QueryFirstOrDefault<VeiculoEntity>(sql, entity);
        }

        public VeiculoEntity ObterPorId(int id)
        {
            var sql = @"SELECT   [Id]
                                ,[Marca]
                                ,[Modelo]
                                ,[Ano]
                                ,[Placa]
                                ,[Cidade]
                                ,[Uf]
                                ,[ClienteId]
                                ,[Ativo]
                                ,[DataCadastro]
                                ,[DataAtualizacao]
                        FROM [Veiculo]
                        WHERE [Id] = @id";

            return QueryFirstOrDefault<VeiculoEntity>(sql, new { id });
        }

        public IEnumerable<VeiculoEntity> ObterPorPlacaCidadeEstado(string? placa, string? cidade, string? uf)
        {
            var sql = new StringBuilder();
            
            sql.AppendLine(@"SELECT  [Id]
                                    ,[Marca]
                                    ,[Modelo]
                                    ,[Ano]
                                    ,[Placa]
                                    ,[Cidade]
                                    ,[Uf]
                                    ,[ClienteId]
                                    ,[Ativo]
                                    ,[DataCadastro]
                                    ,[DataAtualizacao]
                             FROM [Veiculo]
                             WHERE 1 = 1");

            if (!string.IsNullOrEmpty(placa)) sql.AppendLine($"AND [Placa] LIKE '%{placa}%'");
            if (!string.IsNullOrEmpty(cidade)) sql.AppendLine($"AND [Cidade] = '{cidade}'");
            if (!string.IsNullOrEmpty(uf)) sql.AppendLine($"AND [Uf] = '{uf}'");

            return Query<VeiculoEntity>(sql.ToString());
        }
    }
}