using CasosDeUso.Dtos;
using Refit;
using System.Threading.Tasks;

namespace CasosDeUso.ClientApi
{
    public interface IApiViaCep
    {
        [Get("/{cep}/json")]
        Task<EnderecoDto> BuscarEndereco(string cep);
    }
}