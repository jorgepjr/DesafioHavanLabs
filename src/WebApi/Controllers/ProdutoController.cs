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

            if (cadastrarProduto.PossuiErro)
            {
                return BadRequest(cadastrarProduto.MensagemDoErro);
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

            if (excluirProduto.PossuiErro)
            {
                return BadRequest(excluirProduto.MensagemDoErro);
            }

            return Ok($"ProdutoId: {produtoId} foi excluído com sucesso!");
        }

        [HttpGet]
        [Route("Buscar/{codigo}")]
        public async Task<IActionResult> Get(string codigo)
        {
            var produto = await buscarProdutoPorCodigo.Executar(codigo);

            if (buscarProdutoPorCodigo.PossuiErro)
            {
                return BadRequest(buscarProdutoPorCodigo.MensagemDoErro);
            }

            return Ok(produto);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Put(EditarProdutoDto editarProdutoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(editarProdutoDto);
            }

            await editarProduto.Executar(editarProdutoDto);

            if (editarProduto.PossuiErro)
            {
                return BadRequest(editarProduto.MensagemDoErro);
            }

            return Ok(editarProdutoDto);
        }
    }
}