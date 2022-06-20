using Adaptadores.Interfaces;
using Dominio;
using Moq;

namespace Testes.Mocks
{
    public abstract class PersistenciasMock : DatabaseMock
    {
        public (Mock<IPersistenciaDoProduto> PersistenciaMock, Produto ProdutoMock) PersistenciaDoProdutoBuscarPorIdMock(int id)
        {
            var produto = BuscarProdutoMock(id);

            var persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProduto.Setup(x => x.BuscarPorId(produto.Id)).ReturnsAsync(produto);

            return (persistenciaDoProduto, produto);
        }

        public (Mock<IPersistenciaDoProduto> PersistenciaMock, Produto ProdutoMock) PersistenciaDoProdutoBuscarPorCodigoMock(string codigo)
        {
            var produtoMock = BuscarProdutoPorCodigoMock(codigo);

            var persistenciaDoProdutoMock = new Mock<IPersistenciaDoProduto>();
            persistenciaDoProdutoMock.Setup(x => x.BuscarPorCodigo(codigo)).ReturnsAsync(produtoMock);

            return (persistenciaDoProdutoMock, produtoMock);
        }

        public (Mock<IPersistenciaDoCliente> PersistenciaDoCliente, Cliente Cliente) PersistenciaDoClienteBuscarPorIdMock(int id)
        {
            var cliente = BuscarClienteMock(id);

            var persitenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            persitenciaDoCliente.Setup(x => x.BuscarPorId(cliente.Id)).ReturnsAsync(cliente);

            return (persitenciaDoCliente, cliente);
        }

        public (Mock<IPersistenciaDoCliente> PersistenciaMock, Cliente ClienteMock) PersistenciaDoClienteBuscarDocumentoMock(string documento)
        {
            var clienteMock = BuscarClientePorDocumentoMock(documento);

            var persitenciaDoClienteMock = new Mock<IPersistenciaDoCliente>();
            persitenciaDoClienteMock.Setup(x => x.BuscarPorDocumento(clienteMock.Documento)).ReturnsAsync(clienteMock);

            return (persitenciaDoClienteMock, clienteMock);
        }
    }
}
