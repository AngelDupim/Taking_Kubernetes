namespace AngelSystem_Estacionamento.Core.Veiculo.Interface;

public interface IVeiculoService
{
    VeiculoResponseModel Adicionar(VeiculoRequestModel request);
    VeiculoResponseModel Atualizar(int id, VeiculoRequestModel request);
    VeiculoResponseModel Excluir(int id);
    VeiculoResponseModel ObterPorId(int id);
    ListaVeiculoResponseModel ObterPorPlacaCidadeEstado(string? placa, string? cidade, string? uf);

}