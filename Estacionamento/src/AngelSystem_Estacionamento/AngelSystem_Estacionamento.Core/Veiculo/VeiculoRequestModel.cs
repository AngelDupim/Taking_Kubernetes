namespace AngelSystem_Estacionamento.Core.Veiculo;

public class VeiculoRequestModel
{
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Ano { get; set; }
    public required string Placa { get; set; }
    public required string Cidade { get; set; }
    public required string Uf { get; set; }
    public int ClienteId { get; set; }
}