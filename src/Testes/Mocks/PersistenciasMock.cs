using Adaptadores.Interfaces;
using Moq;

namespace Testes.Mocks
{
    public abstract class PersistenciasMock
    {
        public static Mock<IPersistenciaDoProduto> BuscarProdutoPorIdMock()
        {
            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProduto.Setup(x => x.BuscarPorId(It.IsAny<int>())).ReturnsAsync(ModelsMock.ProdutoMock);

            return persistenciaDoProduto;
        }

        public static Mock<IPersistenciaDoCliente> BuscarClientePorIdMock()
        {
            var persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            persistenciaDoCliente.Setup(x => x.BuscarPorId(It.IsAny<int>())).ReturnsAsync(ModelsMock.ClienteMock);

            return persistenciaDoCliente;
        }
    }
}
