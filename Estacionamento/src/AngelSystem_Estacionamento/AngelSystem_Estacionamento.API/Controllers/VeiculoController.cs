using AngelSystem_Estacionamento.API.Config;
using AngelSystem_Estacionamento.Core.Veiculo;
using AngelSystem_Estacionamento.Core.Veiculo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngelSystem_Estacionamento.API.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VeiculoController : BaseController<VeiculoController>
{
    private readonly IVeiculoService _veiculoService;

    /// <summary>
    /// Construtor do Veículo
    /// </summary>
    /// <param name="veiculoService">Dependência da Service</param>
    public VeiculoController(IVeiculoService veiculoService) => _veiculoService = veiculoService;

    /// <summary>
    /// Adicionar Veículo 
    /// </summary>
    /// <param name="request">Dados do veículo a ser adicionado</param>
    /// <returns>Dados do veículo adicionado</returns>
    /// <response code="201">Dados do veículo adicionado</response>
    /// <response code="400">Erro ao adicionar o veículo</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPost]
    [ProducesResponseType(typeof(VeiculoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Adicionar(VeiculoRequestModel request)
    {
        try
        {
            var retorno = _veiculoService.Adicionar(request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }

    }

    /// <summary>
    /// Atualizar os dados do veículo
    /// </summary>
    /// <param name="id">Id do veículo a atualizar</param>
    /// <param name="request">Dados do veículo atualizado</param>
    /// <returns></returns>
    /// <response code="200">Dados do veículo atualizado</response>
    /// <response code="400">Erro ao atualizar o veículo</response>
    /// <response code="404">Veículo não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(VeiculoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Atualizar(int id, VeiculoRequestModel request)
    {
        try
        {
            var retorno = _veiculoService.Atualizar(id, request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    ///  Desativar um veículo
    /// </summary>
    /// <param name="id">Id do veículo</param>
    /// <returns></returns>
    /// <response code="200">Veículo desativado</response>
    /// <response code="400">Erro ao desativar o veículo</response>
    /// <response code="404">Veículo não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(VeiculoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Excluir(int id)
    {
        try
        {
            var retorno = _veiculoService.Excluir(id);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    ///  Buscar dados do veículo por id
    /// </summary>
    /// <param name="id">id do veículo</param>
    /// <returns></returns>
    /// <response code="200">Dados do veículo</response>
    /// <response code="404">Veículo não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VeiculoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult ObterPorId(int id)
    {
        try
        {
            var retorno = _veiculoService.ObterPorId(id);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    /// Buscar dados do veículo pela Placa e/ou Cidade e/ou UF
    /// </summary>
    /// <param name="placa">Placa do veículo</param>
    /// <param name="cidade">Cidade do veículo</param>
    /// <param name="uf">UF do veículo</param>
    /// <returns></returns>
    /// <response code="200">Lista dos veículo</response>
    /// <response code="404">Veículo não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpGet("ObterPorPlacaCidadeEstado")]
    [ProducesResponseType(typeof(ListaVeiculoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult ObterPorPlacaCidadeEstado([FromQuery] string? placa, string? cidade, string? uf)
    {
        try
        {
            var retorno = _veiculoService.ObterPorPlacaCidadeEstado(placa, cidade, uf);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }
}