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
            var persistenciaMock = BuscarProdutoPorIdMock();

            var editarProduto = new EditarProduto(persistenciaMock.Object);

            await editarProduto.Executar(ModelsMock.ProdutoDtoMock, 2);

            persistenciaMock.Verify(x=>x.Atualizar(It.IsAny<Produto>()), Times.Once());
        }
    }
}
