using CasosDeUso.Produtos;
using Dominio;
using Dominio.Interfaces;
using Moq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class ExcluirProdutoTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveExcluirProdutoPorId()
        {
            //Arrange
            int produtoId = 1;
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorIdMock(produtoId);
            var excluirProduto = new ExcluirProduto(persistenciaDoProduto.Object);

            //Action
            await excluirProduto.Executar(produtoId);

            //Assert
            persistenciaDoProduto.Verify(x => x.Excluir(It.IsAny<Produto>()), Times.Once());
        }

        [Fact]
        public async Task DeveRetornarErroCasoProdutoNaoExistir()
        {
            //Arrange
            int produtoId = 0;
            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            var excluirProduto = new ExcluirProduto(persistenciaDoProduto.Object);

            //Action
            await excluirProduto.Executar(produtoId);

            //Assert
            Assert.True(excluirProduto.PossuiErro);
            Assert.Equal("Produto não encontrado!", excluirProduto.MensagemDoErro);
        }
    }
}
