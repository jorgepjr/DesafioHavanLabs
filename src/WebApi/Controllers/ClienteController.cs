using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Clientes;
using CasosDeUso.Enderecos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly CadastrarCliente cadastrarCliente;
        private readonly ExcluirCliente excluirCliente;
        private readonly BuscarEndereco buscarEndereco;

        public ClienteController(IPersistenciaDoCliente persistenciaDoCliente, IApiViaCep apiViaCep)
        {
            this.cadastrarCliente = new CadastrarCliente(persistenciaDoCliente);
            this.excluirCliente = new ExcluirCliente(persistenciaDoCliente);
            this.buscarEndereco = new BuscarEndereco(apiViaCep);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clienteDto);
            }

            await cadastrarCliente.Executar(clienteDto);

            if (cadastrarCliente.Erros.Any())
            {
                return BadRequest(cadastrarCliente.Erros.First().Value);
            }

            var endereco = await buscarEndereco.Executar(clienteDto.Cep);

            var cliente = new {dadosDoCliente = clienteDto, endereco };

            return Ok(cliente);
        }

        [HttpDelete]
        public async Task<IActionResult> Post(int? clienteId)
        {
            if (clienteId is null)
            {
                return BadRequest($"{clienteId} invalido!");
            }

            await excluirCliente.Executar(clienteId.Value);

            if (excluirCliente.Erros.Any())
            {
                return BadRequest(excluirCliente.Erros.First().Value);
            }

            return Ok($"ClienteId: {clienteId} foi excluído com sucesso!");
        }
    }
}
