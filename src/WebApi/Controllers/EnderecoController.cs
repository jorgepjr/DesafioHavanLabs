using CasosDeUso.ClientApi;
using CasosDeUso.Enderecos;
using Microsoft.AspNetCore.Mvc;
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

            if (buscarEndereco.PossuiErro)
            {
                return BadRequest(buscarEndereco.MensagemDoErro);
            }

            return Ok(endereco);
        }
    }
}
