using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Revisão1.Configuration;

namespace Revisão1.Controllers
{

    //onde faz o retorno customizado

    public abstract class PrincipalController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(T data, string message = null)
        {
            var response = new RetornoApiCustomizado<T>
            {
                Sucesso = true,
                Mensagem = message,
                Dados = data
            };
            return Ok(response);
        }

        protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados inválidos")
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            var response = new RetornoApiCustomizado<object>
            {
                Sucesso = false,
                Mensagem = message,
                Dados = erros.Select(n => n.ErrorMessage).ToArray()
            };
            return BadRequest(response);
        }
    }

}
