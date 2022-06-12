using Adaptadores.Interfaces;
using Dominio;
using System;
using System.Threading.Tasks;

namespace CasosDeUso.Clientes
{
    public class BuscarClientePorDocumento : CasoDeUsoBase
    {
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public BuscarClientePorDocumento(IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task<Cliente> Executar(string documento)
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
    }
}
