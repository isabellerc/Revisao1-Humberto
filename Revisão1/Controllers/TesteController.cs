//using Microsoft.AspNetCore.Mvc;
//using Revisão1.Controllers;
//using Revisão1.Models.Request;

//namespace ExemploAPI.Controllers //acho que esse namespace está errado (verificar nas outras classes tambem)
//{
//    [ApiController]
//    [Route("api/[controller]")] //[controller]
//    //é uma variável ele substitui pelo nome do controller 
//    //exemplo: rota/teste
//    public class TesteController : PrincipalController
//    {
//        [HttpGet]
//        public IActionResult Get()
//        //assinatura do método voce tem IActionResult
//        //IActionResult --> Status do protocolo http

//        {
//            return Ok("Minha primeira request");
//            //Ok() é a função de status 200 do protocolo http

//            //Not found();
//            //IActionResult do 404
//        }

//        [HttpPost]
//        public IActionResult Post(JogoViewModel jogoViewModel)
//        {

//            if (!ModelState.IsValid)
//            {
//                ApiBadRequestResponse(ModelState, "Dados Inválidos");
//            }
//            //if (alunoViewModel.Idade < 10)
//            //{
//            //    return BadRequest("Idade inválida");
//            //}
//            return Ok("Jogo criado com sucesso");
//        }
//    }
//}

