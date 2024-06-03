namespace AngelSystem_Estacionamento.Core.Configs
{
    public static class VariaveisAmbientes
    {

        private static string _connectionSqlServer;

        public static string ConnectionSqlServer
        {

            get {                  
                var connection = Environment.GetEnvironmentVariable("CONNECTION_SQLSERVER");
                var dataBase = Environment.GetEnvironmentVariable("DATA_BASE");
                var password = Environment.GetEnvironmentVariable("SA_PASSWORD");

                string connectionString = $"{connection}Database={dataBase};Password={password};";

                if (!string.IsNullOrEmpty(connectionString))
                 return  _connectionSqlServer = connectionString;
                else
                    return _connectionSqlServer;
            }

            set  => _connectionSqlServer = value; 
        }
    }
}
