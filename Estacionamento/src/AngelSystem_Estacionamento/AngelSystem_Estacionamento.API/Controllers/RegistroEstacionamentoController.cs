using AngelSystem_Estacionamento.API.Config;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngelSystem_Estacionamento.API.Controllers;

/// <summary>
/// </summary
[Route("api/[controller]")]
[ApiController]
public class RegistroEstacionamentoController : BaseController<RegistroEstacionamentoController>
{
    private readonly IRegistroEstacionamentoService _registroEstacionamentoService;

    /// <summary>
    /// Construtor da Controller
    /// </summary>
    /// <param name="registroEstacionamentoService">Dependência</param>
    public RegistroEstacionamentoController(IRegistroEstacionamentoService registroEstacionamentoService)
        => _registroEstacionamentoService = registroEstacionamentoService;

    /// <summary>
    /// Adicionar Registro Estacionamento 
    /// </summary>
    /// <param name="request">Dados do registro a ser adicionado</param>
    /// <returns>Dados do registro adicionado</returns>
    /// <response code="200">Dados do registro adicionado</response>
    /// <response code="400">Erro ao adicionar o registro</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPost]
    [ProducesResponseType(typeof(RegistroEstacionamentoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Adicionar(RegistroEstacionamentoRequestModel request)
    {
        try
        {
            var retorno = _registroEstacionamentoService.Adicionar(request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }

    }

    /// <summary>
    /// Atualizar Registro Estacionamento 
    /// </summary>
    /// <param name="request">Dados do registro a ser alterado</param>
    /// <returns>Dados do registro alterado</returns>
    /// <response code="201">Dados do registro alterado</response>
    /// <response code="400">Erro ao adicionar o registro</response>
    /// <response code="500">Erro no servidor</response>
    [HttpPatch]
    [ProducesResponseType(typeof(RegistroEstacionamentoResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult AtualizarValoresSaida([FromBody] RegistroEstacionamentoRequestModel request)
    {
        try
        {
            var retorno = _registroEstacionamentoService.AtualizarValoresSaida(request);
            return Response(StatusCodes.Status200OK, retorno, retorno.ValidationResult);
        }
        catch (Exception ex)
        {
            return ErrorServidor(ex.Message);
        }

    }

}
