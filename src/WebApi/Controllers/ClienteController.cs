using CasosDeUso.ClientApi;
using CasosDeUso.Dtos;
using CasosDeUso.Enderecos;
using CasosDeUso.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICadastroDoCliente cadastroDoCliente;
        private readonly BuscarEndereco buscarEndereco;

        public ClienteController(IApiViaCep apiViaCep, ICadastroDoCliente cadastroDoCliente)
        {
            this.buscarEndereco = new BuscarEndereco(apiViaCep);
            this.cadastroDoCliente = cadastroDoCliente;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clienteDto);
            }

            await cadastroDoCliente.Registrar(clienteDto);

            if (cadastroDoCliente.PossuiErro())
            {
                return BadRequest(cadastroDoCliente.MensagemDeErro());
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

            await cadastroDoCliente.Excluir(clienteId.Value);

            if (cadastroDoCliente.PossuiErro())
            {
                return BadRequest(cadastroDoCliente.MensagemDeErro());
            }

            return Ok($"ClienteId: {clienteId} foi excluído com sucesso!");
        }

        [HttpGet]
        [Route("Buscar/{documento}")]
        public async Task<IActionResult> Get(string documento)
        {
            var cliente = await cadastroDoCliente.BuscarPorDocumento(documento);

            if (cadastroDoCliente.PossuiErro())
            {
                return BadRequest(cadastroDoCliente.MensagemDeErro());
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

            await cadastroDoCliente.Atualizar(atualizarClienteDto);

            if (cadastroDoCliente.PossuiErro())
            {
                return BadRequest(cadastroDoCliente.MensagemDeErro());
            }

            return Ok("Ação realizada com sucesso!");
        }
    }
}