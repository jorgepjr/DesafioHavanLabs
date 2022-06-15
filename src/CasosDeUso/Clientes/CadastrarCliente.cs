using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using Dominio;
using System.Threading.Tasks;

namespace CasosDeUso.Clientes
{
    public class CadastrarCliente : CasoDeUsoBase
    {
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public CadastrarCliente(IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task Executar(ClienteDto clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome, clienteDto.Documento, clienteDto.Cep);

            var jaPossuiCadastro = await persistenciaDoCliente.DoumentoJaCadastrado(clienteDto.Documento);

            if (jaPossuiCadastro)
            {
                Erros.Add("Erro", "Cliente já possui cadastro!");
                return;
            }

            await persistenciaDoCliente.Salvar(cliente);
        }
    }
}
