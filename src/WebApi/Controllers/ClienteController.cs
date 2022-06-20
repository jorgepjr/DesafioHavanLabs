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
        private readonly BuscarClientePorDocumento buscarClientePorDocumento;
        private readonly CadastrarCliente cadastrarCliente;
        private readonly ExcluirCliente excluirCliente;
        private readonly AtualizarCliente atualizarCliente;
        private readonly BuscarEndereco buscarEndereco;

        public ClienteController(IPersistenciaDoCliente persistenciaDoCliente, IApiViaCep apiViaCep)
        {
            this.buscarClientePorDocumento = new BuscarClientePorDocumento(persistenciaDoCliente);
            this.cadastrarCliente = new CadastrarCliente(persistenciaDoCliente);
            this.excluirCliente = new ExcluirCliente(persistenciaDoCliente);
            this.atualizarCliente = new AtualizarCliente(persistenciaDoCliente);
            this.buscarEndereco = new BuscarEndereco(apiViaCep);
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clienteDto);
            }

            await cadastrarCliente.Executar(clienteDto);

            if (cadastrarCliente.PossuiErro)
            {
                return BadRequest(cadastrarCliente.MensagemDoErro);
            }

            var endereco = await buscarEndereco.Executar(clienteDto.Cep);

            var informacoesDoCliente = new { clienteDto, endereco };

            return Ok(informacoesDoCliente);
        }

        [HttpDelete]
        [Route("Excluir/{clienteId}")]
        public async Task<IActionResult> Post(int? clienteId)
        {
            if (clienteId is null)
            {
                return BadRequest($"{clienteId} invalido!");
            }

            await excluirCliente.Executar(clienteId.Value);

            if (excluirCliente.PossuiErro)
            {
                return BadRequest(excluirCliente.MensagemDoErro);
            }

            return Ok($"ClienteId: {clienteId} foi excluído com sucesso!");
        }

        [HttpGet]
        [Route("Buscar/{documento}")]
        public async Task<IActionResult> Get(string documento)
        {
            var cliente = await buscarClientePorDocumento.Executar(documento);

            if (buscarClientePorDocumento.PossuiErro)
            {
                return BadRequest(buscarClientePorDocumento.MensagemDoErro);
            }

            var endereco = await buscarEndereco.Executar(cliente.Cep);

            var informacoesDoCliente = new { cliente, endereco };

            return Ok(informacoesDoCliente);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Put([FromBody] AtualizarClienteDto atualizarClienteDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(atualizarClienteDto);
            }

            await atualizarCliente.Executar(atualizarClienteDto);

            if (atualizarCliente.PossuiErro)
            {
                return BadRequest(atualizarCliente.MensagemDoErro);
            }

            return Ok("Ação realizada com sucesso!");
        }
    }
}