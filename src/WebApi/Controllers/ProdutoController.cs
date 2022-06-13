using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly BuscarProdutoPorCodigo buscarProdutoPorCodigo;
        private readonly CadastrarProduto cadastrarProduto;
        private readonly EditarProduto editarProduto;
        private readonly ExcluirProduto excluirProduto;


        public ProdutoController(IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto);
            this.cadastrarProduto = new CadastrarProduto(persistenciaDoProduto);
            this.excluirProduto = new ExcluirProduto(persistenciaDoProduto);
            this.editarProduto = new EditarProduto(persistenciaDoProduto);

        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Post(ProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(produtoDto);
            }

            await cadastrarProduto.Executar(produtoDto);

            if (cadastrarProduto.Erros.Any())
            {
                return BadRequest(cadastrarProduto.Erros.First().Value);
            }

            return Ok("Produto cadastrado com sucesso!");
        }

        [HttpDelete]
        [Route("Excluir/{produtoId}")]
        public async Task<IActionResult> Post(int? produtoId)
        {
            if (produtoId is null)
            {
                return BadRequest($"{produtoId} invalido!");
            }

            await excluirProduto.Executar(produtoId.Value);

            if (excluirProduto.Erros.Any())
            {
                return BadRequest(excluirProduto.Erros.First().Value);
            }

            return Ok($"ProdutoId: {produtoId} foi excluído com sucesso!");
        }

        [HttpGet]
        [Route("Buscar/{codigo}")]
        public async Task<IActionResult> Get(string codigo)
        {
            var produto = await buscarProdutoPorCodigo.Executar(codigo);

            if (buscarProdutoPorCodigo.Erros.Any())
            {
                return BadRequest(buscarProdutoPorCodigo.Erros.First().Value);
            }

            return Ok(produto);
        }

        [HttpPut]
        [Route("Editar/{produtoId}")]
        public async Task<IActionResult> Put(ProdutoDto produtoDto, int produtoId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(produtoDto);
            }

            await editarProduto.Executar(produtoDto, produtoId);

            if (editarProduto.Erros.Any())
            {
                return BadRequest(editarProduto.Erros.First().Value);
            }

            return Ok(produtoDto);
        }
    }
}