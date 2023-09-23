using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Revisão1.Controllers;
using Revisão1.Models.CustomValidations.ExemploAPI.Models.CustonValidations;
using Revisão1.Models.Request;

namespace ExemploAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : PrincipalController
    {
        private readonly string _RegistroJogoCaminhoArquivo;

        public JogoController()
        {
            _RegistroJogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "JogosMega.json");
        }

        #region Métodos arquivo
        private List<JogoViewModel> LerJogosDoArquivo()
        {
            if (!System.IO.File.Exists(_RegistroJogoCaminhoArquivo))
            {
                return new List<JogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_RegistroJogoCaminhoArquivo);

            //json = "[" + json + "]";

            // Em seguida, você pode desserializar o JSON em uma lista de objetos JogoViewModel:
            List<JogoViewModel> listaDeJogos = JsonConvert.DeserializeObject<List<JogoViewModel>>(json);

            // Agora, você pode retornar a listaDeJogos, se necessário:
            return listaDeJogos;

        }

        private int ObterProximoCodigoDisponivel()
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            if (jogos.Any())
            {
                return jogos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverJogosNoArquivo(List<JogoViewModel> jogos)
        {
            string json = JsonConvert.SerializeObject(jogos);
            System.IO.File.WriteAllText(_RegistroJogoCaminhoArquivo, json);
        }
        #endregion


        #region Operações do crud
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            return Ok(jogos);
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            JogoViewModel jogo = jogos.Find(p => p.Codigo == codigo);
            if (jogo == null)
            {
                return NotFound();
            }

            return Ok(jogo);
        }



        [HttpPost]

        public IActionResult Post([FromBody] NovoJogoViewModel jogo)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState, "Dados Inválidos");
            }

            List<JogoViewModel> jogos = LerJogosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            JogoViewModel novoJogo = new JogoViewModel()
            
            {
                Codigo = proximoCodigo,
                Nome = jogo.Nome,
                Idade = jogo.Idade,
                Cpf = jogo.Cpf,
                primeiroNro = jogo.primeiroNro,
                segundoNro = jogo.segundoNro,
                terceiroNro = jogo.terceiroNro,
                quartoNro = jogo.quartoNro,
                quintoNro = jogo.quintoNro,
                sextoNro = jogo.sextoNro,
                dataJogo = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
            };


            jogos.Add(novoJogo);
            EscreverJogosNoArquivo(jogos);

            return ApiResponse(novoJogo, "Jogo criado com sucesso");
            //return CreatedAtAction(nameof(Get), new { codigo = novoJogo.Codigo }, novoJogo);
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo, [FromBody] EditaJogoViewModel jogo)
        {
            if (jogo == null)
                return BadRequest();

            List<JogoViewModel> jogos = LerJogosDoArquivo();
            int index = jogos.FindIndex(p => p.Codigo == codigo);
            if (index == -1)
                return NotFound();

            JogoViewModel jogoEditado = new JogoViewModel()
            {
                Codigo = codigo,
                Nome = jogo.Nome,
                Idade = jogo.Idade,
                Cpf = jogo.Cpf,
                primeiroNro = jogo.primeiroNro,
                segundoNro = jogo.segundoNro,
                terceiroNro = jogo.terceiroNro,
                quartoNro = jogo.quartoNro,
                quintoNro = jogo.quintoNro,
                sextoNro = jogo.sextoNro,
            };

            jogos[index] = jogoEditado;
            EscreverJogosNoArquivo(jogos);

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            List<JogoViewModel> jogos = LerJogosDoArquivo();
            JogoViewModel jogo = jogos.Find(p => p.Codigo == codigo);
            if (jogo == null)
                return NotFound();

            jogos.Remove(jogo);
            EscreverJogosNoArquivo(jogos);

            return NoContent();
        }
        #endregion
    }
}
