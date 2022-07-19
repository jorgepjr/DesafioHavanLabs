using CasosDeUso.Dtos;
using CasosDeUso.Interfaces;
using CasosDeUso.Vendas;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Factories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly CriarPreVenda criarPreVenda;

        public PreVendaController(
            IPersistenciaDaPreVenda persistenciaDaPreVenda,
            ICadastroDoCliente cadastroDoCliente,
            IPersistenciaDoProduto persistenciaDoProduto)
        {
            criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda, persistenciaDoProduto, cadastroDoCliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PreVendaDto preVendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(preVendaDto);
            }

            var preVenda = await criarPreVenda.Executar(preVendaDto);

            if (criarPreVenda.PossuiErro)
            {
                return BadRequest(criarPreVenda.MensagemDoErro);
            }

            var vendaDto = PreVendaFactory.Criar(preVenda.Cliente, preVenda);

            return Ok(vendaDto);
        }
    }
}
