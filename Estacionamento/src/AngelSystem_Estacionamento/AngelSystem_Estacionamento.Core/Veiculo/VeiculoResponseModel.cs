using AngelSystem_Estacionamento.Core.Configs;

namespace AngelSystem_Estacionamento.Core.Veiculo;

public class VeiculoResponseModel : Validator
{
    public int Id { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Ano { get; set; }
    public string? Placa { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }
    public int ClienteId { get; set; }
    public string? Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public override bool IsValid() => ValidationResult.IsValid;
}