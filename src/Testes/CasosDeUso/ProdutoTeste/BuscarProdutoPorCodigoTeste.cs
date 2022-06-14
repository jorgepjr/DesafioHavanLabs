using Adaptadores.Interfaces;
using CasosDeUso.Produtos;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class BuscarProdutoPorCodigoTeste
    {
        Mock<IPersistenciaDoProduto> persistenciaDoProduto;

        public BuscarProdutoPorCodigoTeste()
        {
            this.persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
        }

        [Fact]
        public async Task DeveBuscarProdutoPeloCodigo()
        {
            //Arrange
            var codigo = "123";
            var produtoMock = ModelsMock.ProdutoMock;
            persistenciaDoProduto.Setup(x => x.BuscarPorCodigo(produtoMock.Codigo)).ReturnsAsync(produtoMock);
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
            var buscarProdutoPorCodigo = new BuscarProdutoPorCodigo(persistenciaDoProduto.Object);

            //Action
            var produto = await buscarProdutoPorCodigo.Executar("554");

            //Assert
            Assert.Equal("Produto não encontrado!", buscarProdutoPorCodigo.Erros.First().Value);
        }
    }
}
