using AngelSystem_Estacionamento.Core.Cliente;
using AngelSystem_Estacionamento.Core.Cliente.Interface;
using AngelSystem_Estacionamento.Infrastructure.Context;
using System.Text;

namespace AngelSystem_Estacionamento.Infrastructure.Persistence
{
    public class ClienteRepository : SqlServerContext<ClienteEntity>, IClienteRepository
    {
        public ClienteEntity Adicionar(ClienteEntity entity)
        {
            var sql = @"INSERT INTO [Cliente]
                                (  
                                   [NomeCompleto]
                                  ,[CpfCnpj]
                                  ,[TipoPessoa]
                                  ,[Telefone]
                                  ,[Email]
                                  ,[Ativo]
                                  ,[DataCadastro]
                                  ,[DataAtualizacao]
                                )                        
                        OUTPUT     INSERTED.[Id]
                                  ,INSERTED.[NomeCompleto]
                                  ,INSERTED.[CpfCnpj]
                                  ,INSERTED.[TipoPessoa]
                                  ,INSERTED.[Telefone]
                                  ,INSERTED.[Email]
                                  ,INSERTED.[Ativo]
                                  ,INSERTED.[DataCadastro]
                                  ,INSERTED.[DataAtualizacao]
                        VALUES (
                                 @NomeCompleto
                                ,@CpfCnpj
                                ,@TipoPessoa
                                ,@Telefone
                                ,@Email
                                ,@Ativo
                                ,@DataCadastro
                                ,@DataAtualizacao
                               )";

            return QueryFirstOrDefault<ClienteEntity>(sql, entity);
        }

        public ClienteEntity Atualizar(ClienteEntity entity)
        {
            var sql = @"UPDATE [Cliente] SET
                                [NomeCompleto] = @NomeCompleto
                               ,[Telefone] = @Telefone
                               ,[Email] = @Email
                               ,[Ativo] = @Ativo
                               ,[DataAtualizacao] = @DataAtualizacao
                        OUTPUT  INSERTED.[Id]
                               ,INSERTED.[NomeCompleto]
                               ,INSERTED.[CpfCnpj]
                               ,INSERTED.[TipoPessoa]
                               ,INSERTED.[Telefone]
                               ,INSERTED.[Email]
                               ,INSERTED.[Ativo]
                               ,INSERTED.[DataCadastro]
                               ,INSERTED.[DataAtualizacao]
                        WHERE [Id] = @Id";

            return QueryFirstOrDefault<ClienteEntity>(sql, entity);
        }

        public ClienteEntity Excluir(ClienteEntity entity)
        {
            var sql = @"UPDATE [Cliente] SET 
                                [Ativo] = @Ativo
                               ,[DataAtualizacao] = @DataAtualizacao
                        OUTPUT  INSERTED.[Id]
                               ,INSERTED.[NomeCompleto]
                               ,INSERTED.[CpfCnpj]
                               ,INSERTED.[TipoPessoa]
                               ,INSERTED.[Telefone]
                               ,INSERTED.[Email]
                               ,INSERTED.[Ativo]
                               ,INSERTED.[DataCadastro]
                               ,INSERTED.[DataAtualizacao]
                        WHERE [Id] = @Id";

            return QueryFirstOrDefault<ClienteEntity>(sql, entity);
        }

        public ClienteEntity ObterPorId(int id)
        {
            var sql = @"SELECT  [Id]
                               ,[NomeCompleto]
                               ,[CpfCnpj]
                               ,[TipoPessoa]
                               ,[Telefone]
                               ,[Email]
                               ,[Ativo]
                               ,[DataCadastro]
                               ,[DataAtualizacao]
                        FROM [Cliente]
                        WHERE [Id] = @id";

            return QueryFirstOrDefault<ClienteEntity>(sql, new { id });
        }

        public IEnumerable<ClienteEntity> ObterPorNomeCpfCnpj(string nome, string cpfCnpj)
        {
            var sql = new StringBuilder();
            sql.AppendLine(@"SELECT  [Id]
                                    ,[NomeCompleto]
                                    ,[CpfCnpj]
                                    ,[TipoPessoa]
                                    ,[Telefone]
                                    ,[Email]
                                    ,[Ativo]
                                    ,[DataCadastro]
                                    ,[DataAtualizacao]
                             FROM [Cliente]
                             WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(nome)) sql.AppendLine($"AND [NomeCompleto] LIKE '%{nome.ToUpper()}%'");
            if(!string.IsNullOrEmpty(cpfCnpj)) sql.AppendLine($"AND [CpfCnpj] = '{cpfCnpj}'");

            return Query<ClienteEntity>(sql.ToString());
        }
    }
}