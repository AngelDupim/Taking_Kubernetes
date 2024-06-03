using AngelSystem_Estacionamento.API.Config;
using AngelSystem_Estacionamento.Core;
using AngelSystem_Estacionamento.Core.Cliente;
using AngelSystem_Estacionamento.Core.Cliente.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngelSystem_Estacionamento.API.Controllers;

/// <summary>
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClienteController : BaseController<ClienteController>
{
    private readonly IClienteService _clienteService;

    /// <summary>
    /// Construtor do Cliente 
    /// </summary>
    /// <param name="clienteService">Dependência da Service</param>
    public ClienteController(IClienteService clienteService) => _clienteService = clienteService;

    /// <summary>
    /// Adicionar Cliente 
    /// </summary>
    /// <param name="request">Dados do cliente a ser adicionado.TipoPessoa: PF ou PJ</param>
    /// <returns>Dados do cliente adicionado</returns>
    /// <response code="201">Dados do cliente adicionado</response>
    /// <response code="400">Erro ao adicionar o cliente</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPost]
    [ProducesResponseType(typeof(ClienteResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Adicionar(ClienteRequestModel request)
    {
        try
        {
            var retorno = _clienteService.Adicionar(request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }

    }

    /// <summary>
    /// Atualizar os dados do cliente
    /// </summary>
    /// <param name="id">Id do cliente a atualizar</param>
    /// <param name="request">Dados do cliente atualizado</param>
    /// <returns></returns>
    /// <response code="200">Dados do cliente atualizado</response>
    /// <response code="400">Erro ao atualizar o cliente</response>
    /// <response code="404">Cliente não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ClienteResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Atualizar(int id, ClienteRequestModel request)
    {
        try
        {
            var retorno = _clienteService.Atualizar(id, request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    ///  Desativar um cliente
    /// </summary>
    /// <param name="id">Id do cliente</param>
    /// <returns></returns>
    /// <response code="200">Cliente desativado</response>
    /// <response code="400">Erro ao desativar o cliente</response>
    /// <response code="404">Cliente não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ClienteResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Excluir(int id)
    {
        try
        {
            var retorno = _clienteService.Excluir(id);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    ///  Buscar dados do cliente por id
    /// </summary>
    /// <param name="id">id do cliente</param>
    /// <returns></returns>
    /// <response code="200">Dados do cliente</response>
    /// <response code="404">Cliente não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClienteResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult ObterPorId(int id)
    {
        try
        {
            var retorno = _clienteService.ObterPorId(id);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }

    /// <summary>
    /// Buscar dados do cliente por nomeCompleto e/ou cpfCnpj
    /// </summary>
    /// <param name="nomeCompleto">Nome completo do cliente ou parte</param>
    /// <param name="cpfCnpj">Cpf/Cnpj do cliente</param>
    /// <returns></returns>
    /// <response code="200">Lista dos clientes</response>
    /// <response code="404">Cliente não encontrado</response>
    /// <response code="500">Erro no servidor</response>
    [HttpGet("ObterPorNomeCpfCnpj")]
    [ProducesResponseType(typeof(ListaClienteResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult ObterPorNomeCpfCnpj([FromQuery]string? nomeCompleto, string? cpfCnpj)
    {
        try
        {
            var retorno = _clienteService.ObterPorNomeCpfCnpj(nomeCompleto, cpfCnpj);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }
    }
}