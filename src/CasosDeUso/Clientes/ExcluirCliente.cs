using Adaptadores.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso.Clientes
{
   public class ExcluirCliente : CasoDeUsoBase
    {
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public ExcluirCliente(IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task Executar(int clienteId)
        {
            var cliente = await persistenciaDoCliente.BuscarPorId(clienteId);

            if(cliente is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            await persistenciaDoCliente.Excluir(cliente);
        }
    }
}
