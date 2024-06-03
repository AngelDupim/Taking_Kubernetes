using AngelSystem_Estacionamento.Core.Configs;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AngelSystem_Estacionamento.Infrastructure.Context
{
    public class SqlServerContext<TEntity>
    {
        public SqlServerContext() { }
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(VariaveisAmbientes.ConnectionSqlServer.ToString());
            }
        }

        internal T QueryFirstOrDefault<T>(string query)
        {
            using (var con = Connection)
                return con.QueryFirstOrDefault<T>(query);
        }

        internal T QueryFirstOrDefault<T>(string query, object parameters)
        {
            using (var con = Connection)
                return con.QueryFirstOrDefault<T>(query, parameters);
        }

        internal IEnumerable<T> Query<T>(string query)
        {
            using (var con = Connection)
                return con.Query<T>(query);
        }

        internal IEnumerable<T> Query<T>(string query, object parametros) 
        {
            using (var con = Connection)
                return con.Query<T>(query, parametros);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
