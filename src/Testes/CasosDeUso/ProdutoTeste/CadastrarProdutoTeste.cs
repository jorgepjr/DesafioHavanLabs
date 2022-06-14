using Adaptadores.Dtos;
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
    public class CadastrarProdutoTeste
    {
        Mock<IPersistenciaDoProduto> persistenciaDoProduto;
        ProdutoDto produtoDto = new ProdutoDto { Codigo = "123", Nome = "Sapato", Preco = 120.34m, Quantidade = 2 };

        public CadastrarProdutoTeste()
        {
            this.persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
        }

        [Fact]
        public async Task DeveCadastrarProduto()
        {
            //Arrange
            var cadastrarProduto = new CadastrarProduto(persistenciaDoProduto.Object);

            //Action
            await cadastrarProduto.Executar(produtoDto);

            //Assert
            persistenciaDoProduto.Verify(x => x.Salvar(It.IsAny<Produto>()), Times.Once());
        }

        [Fact]
        public async Task DeveRetornarErroCasoCodigoDoProdutoJaCadastrado()
        {
            //Arrange
            persistenciaDoProduto.Setup(x => x.BuscarPorCodigo(It.IsAny<string>())).ReturnsAsync(ModelsMock.ProdutoMock);
            var cadastrarProduto = new CadastrarProduto(persistenciaDoProduto.Object);

            //Action
            await cadastrarProduto.Executar(produtoDto);

            //Assert
            Assert.Equal("Codigo: 123 já cadastrado!", cadastrarProduto.Erros.First().Value);
        }
    }
}
