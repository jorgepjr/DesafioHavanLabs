using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Clientes;
using CasosDeUso.Vendas;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Factories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly BuscarClientePorDocumento buscarClientePorDocumento;
        private readonly CriarPreVenda criarPreVenda;

        public PreVendaController(
            IPersistenciaDaPreVenda persistenciaDaPreVenda,
            IPersistenciaDoCliente persistenciaDoCliente,
            IPersistenciaDoProduto persistenciaDoProduto)
        {
            buscarClientePorDocumento = new BuscarClientePorDocumento(persistenciaDoCliente);
            criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda, persistenciaDoProduto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PreVendaDto preVendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(preVendaDto);
            }

            var cliente = await buscarClientePorDocumento.Executar(preVendaDto.DocumentoDoCliente);

            var preVenda = await criarPreVenda.Executar(preVendaDto, cliente.Id);

            if (criarPreVenda.Erros.Any())
            {
                return BadRequest(criarPreVenda.Erros.First().Value);
            }

            var vendaDto = PreVendaFactory.Criar(cliente.Nome, preVenda);

            return Ok(vendaDto);
        }
    }
}
