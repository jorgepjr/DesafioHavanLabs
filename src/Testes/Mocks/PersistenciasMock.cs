using CasosDeUso.Interfaces;
using Dominio;
using Dominio.Interfaces;
using Moq;

namespace Testes.Mocks
{
    public abstract class PersistenciasMock : DatabaseMock
    {
        public Mock<IPersistenciaDoProduto> PersistenciaDoProdutoBuscarPorIdMock(int id)
        {
            var produto = BuscarProdutoMock(id);

            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProduto.Setup(x => x.BuscarPorId(produto.Id)).ReturnsAsync(produto);

            return persistenciaDoProduto;
        }

        public Mock<IPersistenciaDoProduto> PersistenciaDoProdutoBuscarPorCodigoMock(string codigo)
        {
            var produtoMock = BuscarProdutoPorCodigoMock(codigo);

            var persistenciaDoProdutoMock = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProdutoMock.Setup(x => x.BuscarPorCodigo(It.IsAny<string>())).ReturnsAsync(produtoMock);

            return persistenciaDoProdutoMock;
        }

        public Mock<IPersistenciaDoCliente> PersistenciaDoClienteBuscarPorIdMock(int id)
        {
            var cliente = BuscarClienteMock(id);

            var persitenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            persitenciaDoCliente.Setup(x => x.BuscarPorId(cliente.Id)).ReturnsAsync(cliente);

            return persitenciaDoCliente;
        }

        public Mock<ICadastroDoCliente> PersistenciaDoClienteBuscarDocumentoMock(string documento)
        {
            var clienteMock = BuscarClientePorDocumentoMock(documento);

            var persitenciaDoClienteMock = new Mock<ICadastroDoCliente>();
            persitenciaDoClienteMock.Setup(x => x.BuscarPorDocumento(clienteMock.Documento)).ReturnsAsync(clienteMock);

            return persitenciaDoClienteMock;
        }
    }
}
