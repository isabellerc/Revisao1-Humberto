using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Revisão1.Controllers;
using Revisão1.Request;

namespace ExemploAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : PrincipalController
    {
        private readonly string _produtoCaminhoArquivo;

        public JogoController()
        {
            _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "produto.json");
        }

        #region Métodos arquivo
        private List<JogoViewModel> LerProdutosDoArquivo()
        {
            if (!System.IO.File.Exists(_produtoCaminhoArquivo))
            {
                return new List<JogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<JogoViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<JogoViewModel> produtos = LerProdutosDoArquivo();
            if (produtos.Any())
            {
                return produtos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverProdutosNoArquivo(List<JogoViewModel> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
        }
        #endregion


        #region Operações do crud
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoViewModel> listaTodosProdutos = LerProdutosDoArquivo();
            return Ok(listaTodosProdutos);
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            List<JogoViewModel> produtos = LerProdutosDoArquivo();
            JogoViewModel produto = produtos.Find(p => p.Codigo == codigo);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]

        public IActionResult Post([FromBody] NovoJogoViewModel jogo)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState, "Dados Inválidos");
            }

            List<JogoViewModel> produtos = LerProdutosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            JogoViewModel novoProduto = new JogoViewModel()
            {
                Codigo = proximoCodigo,
                Descricao = jogo.Descricao,
                Preco = jogo.Preco,
                Estoque = jogo.Estoque,
                Ativo = jogo.Ativo
            };

            produtos.Add(novoProduto);
            EscreverProdutosNoArquivo(produtos);

            return CreatedAtAction(nameof(Get), new { codigo = novoProduto.Codigo }, novoProduto);
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo, [FromBody] EditaJogoViewModel produto)
        {
            if (produto == null)
                return BadRequest();

            List<JogoViewModel> produtos = LerProdutosDoArquivo();
            int index = produtos.FindIndex(p => p.Codigo == codigo);
            if (index == -1)
                return NotFound();

            JogoViewModel alunoEditado = new ViewModel()
            {
                Codigo = codigo,
                Estoque = produto.Estoque,
                Descricao = produto.Descricao,
                Preco = produto.Preco
            };

            produtos[index] = produtoEditado;
            EscreverProdutosNoArquivo(produtos);

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            List<JogoViewModel> produtos = LerProdutosDoArquivo();
            JogoViewModel produto = produtos.Find(p => p.Codigo == codigo);
            if (produto == null)
                return NotFound();

            produtos.Remove(produto);
            EscreverProdutosNoArquivo(produtos);

            return NoContent();
        }
        #endregion
    }
}
