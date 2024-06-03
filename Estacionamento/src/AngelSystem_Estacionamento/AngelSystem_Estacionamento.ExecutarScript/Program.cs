using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Iniciando!");

        var builder = new ConfigurationBuilder().AddEnvironmentVariables();
        var configuration = builder.Build();

        string connectionString = $@"{configuration["CONNECTION_SQLSERVER"]}Database={configuration["DATA_BASE_MASTER"]};Password={configuration["SA_PASSWORD"]};";

        CriarBase(connectionString);
        CriarTabelas(connectionString);
    }

    private static void CriarBase(string connectionString)
    {
        Console.WriteLine("Criação do base!");

        string sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptsSql", "SqlServer-Database.sql");

        if (!File.Exists(sqlFilePath))
        {
            Console.WriteLine($"Arquivo SQL não encontrado: {sqlFilePath}");
            return;
        }

        string sqlScript = File.ReadAllText(sqlFilePath);

        Executar(connectionString, sqlScript);

        Console.WriteLine("Base criada com sucesso.");
    }

    private static void CriarTabelas(string connectionString)
    {
        Console.WriteLine("Criação Tabela!");

        string sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptsSql", "SqlServer.sql");

        if (!File.Exists(sqlFilePath))
        {
            Console.WriteLine($"Arquivo SQL não encontrado: {sqlFilePath}");
            return;
        }

        string sqlScript = File.ReadAllText(sqlFilePath);
        Executar(connectionString, sqlScript);

        Console.WriteLine("Tabelas criada com sucesso.");
    }

    private static void Executar(string connectionString, string sqlScript)
    {
        Console.WriteLine($"Query a aplica: {sqlScript}");
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            conn.Execute(sqlScript);
        }
    }
}