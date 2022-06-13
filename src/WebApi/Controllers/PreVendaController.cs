using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Clientes;
using CasosDeUso.Produtos;
using CasosDeUso.Vendas;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly BuscarClientePorDocumento buscarClientePorDocumento;
        private readonly BuscarProdutoPorCodigo buscarProdutoPorCodigo;
        private readonly CriarPreVenda criarPreVenda;

        public PreVendaController(
            IPersistenciaDaPreVenda persistenciaDaPreVenda,
            IPersistenciaDoCliente persistenciaDoCliente,
            IPersistenciaDoProduto persistenciaDoProduto)
        {
            buscarClientePorDocumento = new BuscarClientePorDocumento(persistenciaDoCliente);
            buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto);
            criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda, persistenciaDoCliente, persistenciaDoProduto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PreVendaDto preVendaDto)
        {
            await criarPreVenda.Executar(preVendaDto);
            //PreVenda prevenda = null;
            //var items = new List<ItemPreVenda>();

            //var cliente = await buscarClientePorDocumento.Executar(preVendaDto.DocumentoDoCliente);

            //foreach (var item in preVendaDto.Itens)
            //{

            //    var produto = await buscarProdutoPorCodigo.Executar(item.CodigoDoProduto);

            //    var total = item.Quantidade * produto.Preco;

            //    var itemPrevenda = new ItemPreVenda(produto, item.Quantidade, produto.Preco, total);

            //    items.Add(itemPrevenda);
            //}

            //prevenda = new PreVenda(cliente, items);

            //var response = new { cliente, itens = prevenda.Itens, valorTotal = items.Sum(x => x.Total) };

            return Ok();
        }
    }
}
