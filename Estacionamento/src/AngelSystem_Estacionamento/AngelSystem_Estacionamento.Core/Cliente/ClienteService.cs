using AngelSystem_Estacionamento.Core.Cliente.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AngelSystem_Estacionamento.Core.Cliente;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private IMapper _mapper;

    public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public ClienteResponseModel Adicionar(ClienteRequestModel request)
    {
        var response = new ClienteResponseModel();

        if (request.TipoPessoa != null)
        {
            if (!request.TipoPessoa.Equals("PF") && !request.TipoPessoa.Equals("PJ")) {

                response.AddErrorValidationResult(StatusCodes.Status400BadRequest, "TipoPessoa só pode ser PF ou PJ");

                return response;
            }
        }
       
        var clienteExiste = ObterPorNomeCpfCnpj(null, request.CpfCnpj);

        if (!clienteExiste.IsValid())
        {
            var clienteAdicionar = _mapper.Map<ClienteEntity>(request);
            clienteAdicionar.Adicionar();

            var retorno = _clienteRepository.Adicionar(clienteAdicionar);
            response = _mapper.Map<ClienteResponseModel>(retorno);
        }
        else
        {
            response.AddErrorValidationResult(StatusCodes.Status400BadRequest, "Cliente já existe!");
        }

        return response;
    }

    public ClienteResponseModel Atualizar(int id, ClienteRequestModel request)
    {
        var clienteAlterar = _mapper.Map<ClienteEntity>(request);

        var dadosCliente = ObterPorId(id);
        if (dadosCliente.IsValid())
        {
            if (dadosCliente.Ativo.Equals("IN"))
            {
                dadosCliente.AddErrorValidationResult(400, "Cliente está desativado!");
                return dadosCliente;
            }

            clienteAlterar.Alterar(id, dadosCliente.DataCadastro, dadosCliente.Ativo);

            var retorno = _clienteRepository.Atualizar(clienteAlterar);
            return _mapper.Map<ClienteResponseModel>(retorno);
        }
        else
        {
            return dadosCliente;
        }
    }

    public ClienteResponseModel Excluir(int id)
    {
        var dadosCliente = ObterPorId(id);
        if (dadosCliente.IsValid())
        {
            var clienteExcluir = _mapper.Map<ClienteEntity>(dadosCliente);
            clienteExcluir.Excluir(dadosCliente.DataCadastro);

            var retorno = _clienteRepository.Excluir(clienteExcluir);
            return _mapper.Map<ClienteResponseModel>(retorno);
        }
        else
        {
            return dadosCliente;
        }
    }

    public ClienteResponseModel ObterPorId(int id)
    {
        var response = new ClienteResponseModel();

        var clienteExistente = _clienteRepository.ObterPorId(id);

        if (clienteExistente != null)
            response = _mapper.Map<ClienteResponseModel>(_clienteRepository.ObterPorId(id));
        else
            response.AddErrorValidationResult(StatusCodes.Status404NotFound, "Cliente não encontrado!");

        return response;
    }

    public ListaClienteResponseModel ObterPorNomeCpfCnpj(string nomeCompleto, string cpfCnpj)
    {
        var response = new ListaClienteResponseModel();

        var clientes = _clienteRepository.ObterPorNomeCpfCnpj(nomeCompleto, cpfCnpj);

        if (!clientes.Any())
            response.AddErrorValidationResult(StatusCodes.Status404NotFound, "Clientes não encontrados!");
        else
            response = _mapper.Map<ListaClienteResponseModel>(clientes);

        return response;
    }
}