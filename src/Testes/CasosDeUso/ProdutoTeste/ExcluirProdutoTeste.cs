using Adaptadores.Interfaces;
using CasosDeUso.Produtos;
using Dominio;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class ExcluirProdutoTeste : PersistenciasMock
    {
        Mock<IPersistenciaDoProduto> persistencia = BuscarProdutoPorIdMock();

        [Fact]
        public async Task DeveExcluirProdutoPorId()
        {
            //Arrange
            int produtoId = 10;
            var excluirProduto = new ExcluirProduto(persistencia.Object);

            //Action
            await excluirProduto.Executar(produtoId);

            //Assert
            persistencia.Verify(x=>x.Excluir(It.IsAny<Produto>()), Times.Once());
        }

        [Fact]
        public async Task DeveRetornarErroCasoProdutoNaoExistir()
        {
            //Arrange
            int produtoId = 10;
            Produto produto = null;
            persistencia.Setup(x=>x.BuscarPorId(produtoId)).ReturnsAsync(produto);
            var excluirProduto = new ExcluirProduto(persistencia.Object);

            //Action
            await excluirProduto.Executar(produtoId);

            //Assert
            Assert.Equal("Produto não encontrado!", excluirProduto.Erros.First().Value);
        }
    }
}
