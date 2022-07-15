using CasosDeUso.Dtos;
using CasosDeUso.Interfaces;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Threading.Tasks;

namespace CasosDeUso.Clientes
{
    public class CadastroDoCliente : CasoDeUsoBase, ICadastroDoCliente
    {
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public CadastroDoCliente(IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task Registrar(ClienteDto clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome, clienteDto.Documento, clienteDto.Cep);

            var jaPossuiCadastro = await persistenciaDoCliente.DoumentoJaCadastrado(clienteDto.Documento);

            if (jaPossuiCadastro)
            {
                Erros.Add("Erro", $"Documento nª: {clienteDto.Documento} já cadastrado!");
                return;
            }

            await persistenciaDoCliente.Salvar(cliente);
        }

        public async Task Atualizar(AtualizarClienteDto atualizarClienteDto)
        {
            var cliente = await persistenciaDoCliente.BuscarPorId(atualizarClienteDto.ClienteId);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            cliente.AtualizarInformacoes(atualizarClienteDto.Nome, atualizarClienteDto.Cep);

            await persistenciaDoCliente.Atualizar(cliente);
        }

        public async Task<Cliente> BuscarPorDocumento(string documento)
        {
            Cliente cliente;

            try
            {
                cliente = await persistenciaDoCliente.BuscarPorDocumento(documento);

            }
            catch (Exception ex)
            {

                Erros.Add("Exception", ex.Message);
                return null;
            }

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return null;
            }

            return cliente;
        }

        public async Task Excluir(int clienteId)
        {
            var cliente = await persistenciaDoCliente.BuscarPorId(clienteId);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            await persistenciaDoCliente.Excluir(cliente);
        }
    }
}
