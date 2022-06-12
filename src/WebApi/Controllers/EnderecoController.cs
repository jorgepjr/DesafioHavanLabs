using Adaptadores.Interfaces;
using CasosDeUso.Enderecos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly BuscarEndereco buscarEndereco;

        public EnderecoController(IApiViaCep apiViaCep)
        {
            this.buscarEndereco = new BuscarEndereco(apiViaCep);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string cep)
        {
            var endereco = await buscarEndereco.Executar(cep);

            if (buscarEndereco.Erros.Any())
            {
                return BadRequest(buscarEndereco.Erros.First().Value);
            }

            return Ok(endereco);
        }
    }
}
