using Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adaptadores.Interfaces
{
    public interface IPersistenciaDoCliente
    {
        Task Salvar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Excluir(Cliente cliente);
        Task<Cliente> BuscarPorId(int id);
        Task<Cliente> BuscarPorDocumento(string documento);
        Task<bool> JaPossuiCadastro(string documento);
        Task<IEnumerable<Cliente>> BuscarTodos();
    }
}
