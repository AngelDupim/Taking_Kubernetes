namespace AngelSystem_Estacionamento.Core.Cliente;

public class ClienteEntity
{
    public int Id { get; set; }
    public required string NomeCompleto { get; set; }
    public required string CpfCnpj { get; set; }
    public required string TipoPessoa { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public string? Ativo { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }

    public void Adicionar()
    {
        DataCadastro = DateTime.Now;
        Ativo = "AT";
    }
    public void Alterar (int id, DateTime dataCadastro, string ativo) 
    {
        Id = id;
        DataCadastro = dataCadastro;
        DataAtualizacao = DateTime.Now;
        Ativo = ativo;
    }
    public void Excluir (DateTime dataCadastro) 
    {
        DataCadastro = dataCadastro;
        DataAtualizacao = DateTime.Now;
        Ativo = "IN";
    }
}