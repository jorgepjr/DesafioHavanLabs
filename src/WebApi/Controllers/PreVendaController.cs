using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Vendas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly CriarPreVenda criarPreVenda;

        public PreVendaController(
            IPersistenciaDaPreVenda persistenciaDaPreVenda,
            IPersistenciaDoCliente persistenciaDoCliente,
            IPersistenciaDoProduto persistenciaDoProduto)
        {
            criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda, persistenciaDoCliente, persistenciaDoProduto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PreVendaDto preVendaDto)
        {
            await criarPreVenda.Executar(preVendaDto);

            return Ok("Pre-venda realizada com sucesso!");
        }
    }
}
