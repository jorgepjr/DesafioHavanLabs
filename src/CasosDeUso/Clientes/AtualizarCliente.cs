using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso.Clientes
{
    public class AtualizarCliente : CasoDeUsoBase
    {
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public AtualizarCliente(IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task Executar(ClienteDto clienteDto, int clienteId)
        {
            var cliente = await persistenciaDoCliente.BuscarPorId(clienteId);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            var jaPossuiCadastro = await persistenciaDoCliente.JaPossuiCadastro(clienteDto.Documento);

            if (jaPossuiCadastro)
            {
                Erros.Add("Erro", "Clinte já cadastrado com este documento!");
            }

            cliente.AtualizarInformacoes(clienteDto.Nome, clienteDto.Documento, clienteDto.Cep);

            await persistenciaDoCliente.Atualizar(cliente);
        }
    }
}
