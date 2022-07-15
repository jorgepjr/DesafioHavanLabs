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
        public async Task DeveEditarInformacoesDoCliente()
        {
            //Arrange
            var atualizarClienteDto = ModelsMock.AtualizarClienteDtoMock;
            var persistenciaDoCliente = PersistenciaDoClienteBuscarPorIdMock(atualizarClienteDto.ClienteId);

            var atualizarCliente = new CadastroDoCliente(persistenciaDoCliente.Object);

            //Action
            await atualizarCliente.Atualizar(atualizarClienteDto);

            //Assert
            persistenciaDoCliente.Verify(x => x.Atualizar(It.IsAny<Cliente>()), Times.Once());
        }
    }
}
