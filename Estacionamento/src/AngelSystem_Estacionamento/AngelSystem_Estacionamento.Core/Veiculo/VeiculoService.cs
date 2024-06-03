using AngelSystem_Estacionamento.Core.Veiculo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AngelSystem_Estacionamento.Core.Veiculo;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private IMapper _mapper;

    public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public VeiculoResponseModel Adicionar(VeiculoRequestModel request)
    {
        var response = new VeiculoResponseModel();

        var veiculoExistente = ObterPorPlacaCidadeEstado(request.Placa, request.Cidade, request.Uf);

        if (veiculoExistente.IsValid())
        {
            response.AddErrorValidationResult(StatusCodes.Status400BadRequest, "Veículo já existe!");
        }
        else 
        {
            var veiculoAdicionar = _mapper.Map<VeiculoEntity>(request);
            veiculoAdicionar.Adicionar();

            var retorno = _veiculoRepository.Adicionar(veiculoAdicionar);
            response = _mapper.Map<VeiculoResponseModel>(retorno);
        }
        return response;
    }

    public VeiculoResponseModel Atualizar(int id, VeiculoRequestModel request)
    {
        var veiculoAlterar = _mapper.Map<VeiculoEntity>(request);

        var dadosVeiculo = ObterPorId(id);
        if (dadosVeiculo.IsValid())
        {
            if (dadosVeiculo.Ativo.Equals("IN"))
            {
                dadosVeiculo.AddErrorValidationResult(400, "Veiculo está desativado!");
                return dadosVeiculo;
            }

            veiculoAlterar.Alterar(id, dadosVeiculo.DataCadastro, dadosVeiculo.Ativo);

            var retorno = _veiculoRepository.Atualizar(veiculoAlterar);
            return _mapper.Map<VeiculoResponseModel>(retorno);
        }
        else
        {
            return dadosVeiculo;
        }
    }

    public VeiculoResponseModel Excluir(int id)
    {
        var veiculoCliente = ObterPorId(id);
        if (veiculoCliente.IsValid())
        {
            var veiculoExcluir = _mapper.Map<VeiculoEntity>(veiculoCliente);
            veiculoExcluir.Excluir(veiculoCliente.DataCadastro);

            var retorno = _veiculoRepository.Excluir(veiculoExcluir);
            return _mapper.Map<VeiculoResponseModel>(retorno);
        }
        else
        {
            return veiculoCliente;
        }
    }

    public VeiculoResponseModel ObterPorId(int id)
    {
        var response = new VeiculoResponseModel();

        var veiculoExistente = _veiculoRepository.ObterPorId(id);

        if (veiculoExistente != null)
            response = _mapper.Map<VeiculoResponseModel>(veiculoExistente);
        else
            response.AddErrorValidationResult(StatusCodes.Status404NotFound, "Veículo não encontrado!");

        return response;

    }

    public ListaVeiculoResponseModel ObterPorPlacaCidadeEstado(string? placa, string? cidade, string? uf)
    {
        var response = new ListaVeiculoResponseModel();

        var veiculos = _veiculoRepository.ObterPorPlacaCidadeEstado(placa, cidade, uf);

        if (!veiculos.Any())
            response.AddErrorValidationResult(StatusCodes.Status404NotFound, "Veículo não encontrados!");
        else
            response = _mapper.Map<ListaVeiculoResponseModel>(veiculos);

        return response;
    }
}