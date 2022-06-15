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

        public async Task Executar(AtualizarClienteDto atualizarClienteDto)
        {
            var cliente = await persistenciaDoCliente.BuscarPorId(atualizarClienteDto.ClienteId);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            var jaPossuiCadastro = await persistenciaDoCliente.JaPossuiCadastro(atualizarClienteDto.Documento);

            if (jaPossuiCadastro)
            {
                Erros.Add("Erro", "Clinte já cadastrado com este documento!");
            }

            cliente.AtualizarInformacoes(atualizarClienteDto.Nome, atualizarClienteDto.Documento, atualizarClienteDto.Cep);

            await persistenciaDoCliente.Atualizar(cliente);
        }
    }
}
