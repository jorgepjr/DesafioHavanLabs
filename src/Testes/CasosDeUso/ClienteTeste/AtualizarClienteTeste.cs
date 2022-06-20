using CasosDeUso.Clientes;
using CasosDeUso.Produtos;
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
            var (persistenciaDoCliente, cliente) = PersistenciaDoClienteBuscarPorIdMock(atualizarClienteDto.ClienteId);

            var atualizarCliente = new AtualizarCliente(persistenciaDoCliente.Object);

            //Action
            await atualizarCliente.Executar(atualizarClienteDto);

            //Assert
            persistenciaDoCliente.Verify(x => x.Atualizar(cliente), Times.Once());
        }
    }
}
