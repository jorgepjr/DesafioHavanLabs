using Dominio;
using System.Threading.Tasks;

namespace Adaptadores.Interfaces
{
    public interface IPersistenciaDaPreVenda
    {
        Task Criar(PreVenda  preVenda);
    }
}
