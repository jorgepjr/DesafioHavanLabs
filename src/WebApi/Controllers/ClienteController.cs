﻿using Adaptadores.Dtos;
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

            if (cadastrarCliente.Erros.Any())
            {
                return BadRequest(cadastrarCliente.Erros.First().Value);
            }

            return Ok("Cliente cadastrado com sucesso!");
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

            if (excluirCliente.Erros.Any())
            {
                return BadRequest(excluirCliente.Erros.First().Value);
            }

            return Ok($"ClienteId: {clienteId} foi excluído com sucesso!");
        }

        [HttpGet]
        [Route("Buscar/{documento}")]
        public async Task<IActionResult> Get(string documento)
        {
            var cliente = await buscarClientePorDocumento.Executar(documento);

            if (buscarClientePorDocumento.Erros.Any())
            {
                return BadRequest(buscarClientePorDocumento.Erros.First().Value);
            }

            var endereco = await buscarEndereco.Executar(cliente.Cep);

            var informacoesDoCliente = new { cliente, endereco };

            return Ok(informacoesDoCliente);
        }

        [HttpPut]
        [Route("Editar/{clienteId}")]
        public async Task<IActionResult> Put(ClienteDto clienteDto, int clienteId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(clienteDto);
            }

            await atualizarCliente.Executar(clienteDto, clienteId);

            if (atualizarCliente.Erros.Any())
            {
              return BadRequest(atualizarCliente.Erros.First().Value);
            }

            return Ok("Ação realizada com sucesso!");
        }
    }
}