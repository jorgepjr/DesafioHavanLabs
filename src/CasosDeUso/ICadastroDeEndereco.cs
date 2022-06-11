using Adaptadores.Dtos;
using System.Threading.Tasks;

namespace CasosDeUso
{
    public interface ICadastroDeEndereco
    {
        Task<EnderecoDto> BuscarEndereco(string cep);
    }
}