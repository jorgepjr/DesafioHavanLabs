using Adaptadores.Dtos;
using Refit;
using System.Threading.Tasks;

namespace Adaptadores.Interfaces
{
    public interface IApiViaCep
    {
        [Get("/{cep}/json")]
        Task<EnderecoDto> BuscarEndereco(string cep);
    }
}