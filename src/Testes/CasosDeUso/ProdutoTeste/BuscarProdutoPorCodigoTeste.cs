using CasosDeUso.Produtos;
using System.Threading.Tasks;
using Testes.Mocks;
using WebApi.Extensions;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class BuscarProdutoPorCodigoTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveBuscarProdutoPeloCodigo()
        {

            //Arrange
            var codigo = "9";
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto.Object);

            //Action
            var produto = await buscarProdutoPorCodigo.Executar(codigo);

            //Assert
            Assert.NotNull(produto);
        }

        [Fact]
        public async Task DeveRetornarErroCasoProdutoNaoEncontrado()
        {
            //Arrange
            var codigo = "3000";
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto.Object);

            //Action
            var resultado = await buscarProdutoPorCodigo.Executar(codigo);

            //Assert
            Assert.True(buscarProdutoPorCodigo.PossuiErro());
            Assert.Equal("Produto não encontrado!", buscarProdutoPorCodigo.MensagemDeErro());
            Assert.Null(resultado);
        }
    }
}
