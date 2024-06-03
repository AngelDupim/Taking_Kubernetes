using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AngelSystem_Estacionamento.API.Config;

/// <summary>
/// Classe para ter uma estrutura padrão de resposta
/// </summary>
/// <typeparam name="TController">Controller está herdando</typeparam>
public abstract class BaseController<TController> : ControllerBase
{
    /// <summary>
    /// Resposta padrão para controller
    /// </summary>
    /// <typeparam name="T">Generico</typeparam>
    /// <param name="status">Status Code da requisição</param>
    /// <param name="response">Objeto de retorno</param>
    /// <param name="validationResult">Validação de erros</param>
    /// <returns>IActionResult conforme o StatusCode </returns>
    protected new IActionResult Response<T>(int status, T response, ValidationResult validationResult) 
    {
        var mensagem = new StringBuilder();

        if (!validationResult.IsValid)
        {
            if (validationResult.Errors.Any())
            {
                foreach (var error in validationResult.Errors)
                {
                    mensagem.AppendLine(error.ErrorMessage);
                    status = Convert.ToInt32(error.ErrorCode);
                }
            }

            if (status == StatusCodes.Status204NoContent) return NoContent();

            return MakeResponse(StatusCode(status, new ErrorResponse { ErrorCode = status, Mensagem = $"{mensagem}"} ));
        }

        return MakeResponse(StatusCode(status, new { response }));
    }

    /// <summary>
    /// Resposta padrão quando tem uma Exception, StatusCode 500
    /// </summary>
    /// <param name="mensagem">mensagem da Exception</param>
    /// <returns>IActionResult com o status 500</returns>
    protected IActionResult ErrorServidor(string mensagem) 
    {
        return MakeResponse(StatusCode(StatusCodes.Status500InternalServerError, new { mensagem }));
    }

    private IActionResult MakeResponse(IActionResult response) => response;
   
    private class ErrorResponse 
    {
        public int ErrorCode { get; set; }
        public required string Mensagem {  get; set; }
    }    
}