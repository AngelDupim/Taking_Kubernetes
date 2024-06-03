namespace AngelSystem_Estacionamento.Core.Cliente.Interface;

public interface IClienteService
{
    ClienteResponseModel Adicionar(ClienteRequestModel request);
    ClienteResponseModel Atualizar(int id, ClienteRequestModel request);
    ClienteResponseModel Excluir(int id);
    ClienteResponseModel ObterPorId(int id);
    ListaClienteResponseModel ObterPorNomeCpfCnpj(string nomeCompleto, string cpfCnpj);
}