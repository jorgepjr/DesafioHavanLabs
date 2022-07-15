using CasosDeUso.Dtos;
using CasosDeUso.Produtos;
using Dominio;
using Dominio.Interfaces;
using Moq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class CadastrarProdutoTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveCadastrarProduto()
        {
            //Arrange
            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            var produtoDto = new ProdutoDto { Codigo = "123", Nome = "Sapato", Preco = 120.34m, Quantidade = 2 };
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
            var codigo = "10";
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var produto = await persistenciaDoProduto.Object.BuscarPorCodigo(codigo);

            var produtoDto = new ProdutoDto { Codigo = produto.Codigo, Nome = "Sapato", Preco = 120.34m, Quantidade = 2 };
            var cadastrarProduto = new CadastrarProduto(persistenciaDoProduto.Object);

            //Action
            await cadastrarProduto.Executar(produtoDto);

            //Assert
            Assert.True(cadastrarProduto.PossuiErro);
            Assert.Equal($"Codigo: {codigo} já cadastrado!", cadastrarProduto.MensagemDoErro);
        }
    }
}
