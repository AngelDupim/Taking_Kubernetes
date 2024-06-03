namespace AngelSystem_Estacionamento.Core.Veiculo;

public class VeiculoEntity
{
    public int Id { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Ano { get; set; }
    public required string Placa { get; set; }
    public required string Cidade { get; set; }
    public required string Uf { get; set; }
    public int ClienteId { get; set; }
    public string Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }

    public void Adicionar()
    {
        DataCadastro = DateTime.Now;
        Ativo = "AT";
    }

    public void Alterar(int id, DateTime datacadastro, string ativo)
    {
        Id = id;
        DataCadastro = datacadastro;
        Ativo = ativo;
        DataAtualizacao = DateTime.Now;
    }

    public void Excluir(DateTime datacadastro)
    {
        DataCadastro = datacadastro;
        Ativo = "IN";
        DataAtualizacao = DateTime.Now;
    }
}