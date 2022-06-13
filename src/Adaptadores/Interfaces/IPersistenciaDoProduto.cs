using Dominio;
using System.Threading.Tasks;

namespace Adaptadores.Interfaces
{
    public interface IPersistenciaDoProduto
    {
        Task Salvar(Produto produto);
        Task Atualizar(Produto produto);
        Task Excluir(Produto produto);
        Task<Produto> BuscarPorCodigo(string codigo);
        Task<Produto> BuscarPorId(int produtoId);
    }
}
