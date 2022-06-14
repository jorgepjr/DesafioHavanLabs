using Adaptadores.Interfaces;
using Moq;

namespace Testes.Mocks
{
    public abstract class PersistenciasMock
    {
        public Mock<IPersistenciaDoProduto> BuscarProdutoPorIdMock()
        {
            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProduto.Setup(x => x.BuscarPorId(It.IsAny<int>())).ReturnsAsync(ModelsMock.ProdutoMock);

            return persistenciaDoProduto;
        }
    }
}
