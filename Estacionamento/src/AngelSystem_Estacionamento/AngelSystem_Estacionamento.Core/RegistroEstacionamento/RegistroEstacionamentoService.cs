using AngelSystem_Estacionamento.Core.Cliente.Interface;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;
using AngelSystem_Estacionamento.Core.TabelaPreco.Interface;
using AngelSystem_Estacionamento.Core.Veiculo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AngelSystem_Estacionamento.Core.RegistroEstacionamento;

public class RegistroEstacionamentoService : IRegistroEstacionamentoService
{
    private readonly IRegistroEstacionamentoRepository _registroEstacionamentoRepository;
    private readonly ITabelaPrecoService _tabelaPrecoService;
    private readonly IClienteService _clienteService;
    private readonly IVeiculoService _veiculoService;

    private IMapper _mapper;

    public RegistroEstacionamentoService(IRegistroEstacionamentoRepository registroEstacionamentoRepository, IMapper mapper,
        ITabelaPrecoService tabelaPrecoService, IClienteService clienteService, IVeiculoService veiculoService)
    {
        _registroEstacionamentoRepository = registroEstacionamentoRepository;
        _tabelaPrecoService = tabelaPrecoService;
        _clienteService = clienteService;
        _veiculoService = veiculoService;

        _mapper = mapper;
    }

    public RegistroEstacionamentoResponseModel Adicionar(RegistroEstacionamentoRequestModel request)
    {
        var response = new RegistroEstacionamentoResponseModel();

        var clienteAtivo = _clienteService.ObterPorId(request.ClienteId);

        if (clienteAtivo != null && clienteAtivo.Ativo.Equals("AT"))
        {
            var veiculoAtivo = _veiculoService.ObterPorId(request.VeiculoId);

            if (veiculoAtivo != null && veiculoAtivo.Equals("AT"))
            {
                var registro = _mapper.Map<RegistroEstacionamentoEntity>(request);
                registro.AdicionarRegistroEstacionamento();

                var retorno = _registroEstacionamentoRepository.Adicionar(registro);

                response = _mapper.Map<RegistroEstacionamentoResponseModel>(retorno);
            }
            else
            {
                response.AddErrorValidationResult(StatusCodes.Status400BadRequest, "Veículo não encontrado ou desativado!");
            }
        }
        else
        {
            response.AddErrorValidationResult(StatusCodes.Status400BadRequest, "Cliente não encontrado ou desativado!");
        }

        return response;
    }

    public RegistroEstacionamentoResponseModel AtualizarValoresSaida(RegistroEstacionamentoRequestModel request)
    {
        var response = new RegistroEstacionamentoResponseModel();

        var registros = _registroEstacionamentoRepository.ObterPorClienteIdVeiculoId(request.ClienteId, request.VeiculoId);

        if (registros.Any())
        {
            var ultimoRegistro = registros.LastOrDefault();

            if (ultimoRegistro != null)
            {
                var dataSaida = DateTime.Now;
                var totalPermanencia = TotalPermanencia(ultimoRegistro.DataEntrada, dataSaida);
                var precoTotal = _tabelaPrecoService.CalcularPrecoCobrar(totalPermanencia);

                ultimoRegistro.AtualizarRegistroEstacionamento(dataSaida, totalPermanencia, precoTotal ?? 0);

                var retorno = _registroEstacionamentoRepository.AtualizarValoresSaida(ultimoRegistro);

                return _mapper.Map<RegistroEstacionamentoResponseModel>(retorno);
            }
        }

        return response;
    }

    private TimeSpan TotalPermanencia(DateTime dataEntrada, DateTime dataSaida)
    {
        TimeSpan tempoPermanencia = dataSaida - dataEntrada;
        return tempoPermanencia;
    }

}