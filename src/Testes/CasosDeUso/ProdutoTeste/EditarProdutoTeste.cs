using CasosDeUso.Produtos;
using Dominio;
using Moq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ProdutoTeste
{
    public class EditarProdutoTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveEditarInformacoesDoProduto()
        {
            //Arrange
            var persistenciaMock = BuscarProdutoPorIdMock();
            var editarProduto = new EditarProduto(persistenciaMock.Object);

            //Action
            await editarProduto.Executar(ModelsMock.ProdutoDtoMock, 2);

            //Assert
            persistenciaMock.Verify(x=>x.Atualizar(It.IsAny<Produto>()), Times.Once());
        }
    }
}
