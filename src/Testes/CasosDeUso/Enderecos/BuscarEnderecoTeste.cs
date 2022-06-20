using Adaptadores.Interfaces;
using CasosDeUso.Enderecos;
using Refit;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testes.CasosDeUso.Enderecos
{
    public class BuscarEnderecoTeste
    {
        [Fact]
        public async Task DeveBuscarEnderecoViaCep()
        {
            //Arrange
            var viaCep = RestService.For<IApiViaCep>("https://viacep.com.br/ws");
            var buscarEndereco = new BuscarEndereco(viaCep);

            //Action
            var endereco = await buscarEndereco.Executar("76806534");

            //Assert
            Assert.Equal("Floresta", endereco.Bairro);
            Assert.Equal("Rua da Fortuna", endereco.Logradouro);
            Assert.Equal("Porto Velho", endereco.Localidade);
            Assert.Equal("RO", endereco.Uf);
            Assert.Equal("76806-534", endereco.Cep);
        }

        [Fact]
        public async Task DeveRetornarErroCasoEnderecoNaoEncontrado()
        {
            //Arrange
            var viaCep = RestService.For<IApiViaCep>("https://viacep.com.br/ws");
            var buscarEndereco = new BuscarEndereco(viaCep);

            //Action
            await buscarEndereco.Executar("76806515");

            //Assert
            Assert.True(buscarEndereco.PossuiErro);
            Assert.Equal("Endereço não encontrado!", buscarEndereco.MensagemDoErro);
        }

        [Fact]
        public async Task DeveRetornarErroDeCepInvalido()
        {
            //Arrange
            var viaCep = RestService.For<IApiViaCep>("https://viacep.com.br/ws");
            var buscarEndereco = new BuscarEndereco(viaCep);

            //Action
            await buscarEndereco.Executar("768065");

            //Assert
            Assert.Equal("Cep inválido!", buscarEndereco.MensagemDoErro);
        }
    }
}
