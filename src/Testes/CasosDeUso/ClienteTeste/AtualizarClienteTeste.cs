using CasosDeUso.Clientes;
using Dominio;
using Moq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ClienteTeste
{
   public class AtualizarClienteTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveEditarInformacoesDoProduto()
        {
            //Arrange
            var persistenciaMock = BuscarClientePorIdMock();
            var atualizarCliente = new AtualizarCliente(persistenciaMock.Object);

            //Action
            await atualizarCliente.Executar(ModelsMock.AtualizarClienteDtoMock);

            //Assert
            persistenciaMock.Verify(x => x.Atualizar(It.IsAny<Cliente>()), Times.Once());
        }
    }
}
