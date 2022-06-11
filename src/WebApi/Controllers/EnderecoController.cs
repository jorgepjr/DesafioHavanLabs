using CasosDeUso;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ICadastroDeEndereco cadastroDeEndereco;

        public EnderecoController(ICadastroDeEndereco cadastroDeEndereco)
        {
            this.cadastroDeEndereco = cadastroDeEndereco;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string cep)
        {
            var endereco = await cadastroDeEndereco.BuscarEndereco(cep);

            return Ok(endereco);
        }
    }
}
