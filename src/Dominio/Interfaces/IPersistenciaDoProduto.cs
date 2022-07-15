using System.Threading.Tasks;

namespace Dominio.Interfaces
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
