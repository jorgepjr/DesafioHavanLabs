using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso
{
    public class CadastroDeEndereco : ICadastroDeEndereco
    {
        private readonly IApiViaCep apiViaCep;

        public CadastroDeEndereco(IApiViaCep apiViaCep)
        {
            this.apiViaCep = apiViaCep;
        }

        public async Task<EnderecoDto> BuscarEndereco(string cep)
        {
           var endereco = await apiViaCep.BuscarEnderecoViaCep(cep);

            return endereco;
        }
    }
}
