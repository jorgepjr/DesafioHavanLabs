using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IPersistenciaDaPreVenda
    {
        Task Criar(PreVenda  preVenda);
    }
}
