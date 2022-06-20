using CasosDeUso.Produtos;
using System.Threading.Tasks;
using Testes.Mocks;
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
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo).PersistenciaMock;
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
            var codigo = "50";
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo).PersistenciaMock;
            var buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto.Object);

            //Action
            var produto = await buscarProdutoPorCodigo.Executar(codigo);

            //Assert
            Assert.True(buscarProdutoPorCodigo.PossuiErro);
            Assert.Equal("Produto não encontrado!", buscarProdutoPorCodigo.MensagemDoErro);
            Assert.Null(produto);
        }
    }
}
