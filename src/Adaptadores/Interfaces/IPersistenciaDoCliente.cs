using Dominio;
using System.Threading.Tasks;

namespace Adaptadores.Interfaces
{
    public interface IPersistenciaDoCliente
    {
        Task Cadastrar(Cliente cliente);

        Task Excluir(Cliente cliente);
        Task<Cliente> BuscarPorId(int id);
        Task<Cliente> BuscarPorDocumento(string documento);
        Task<bool> JaPossuiCadastro(string documento);
    }
}
