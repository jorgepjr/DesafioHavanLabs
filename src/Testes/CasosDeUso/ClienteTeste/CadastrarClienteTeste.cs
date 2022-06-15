using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Clientes;
using Dominio;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.ClienteTeste
{
    public class CadastrarClienteTeste : PersistenciasMock
    {
        Mock<IPersistenciaDoCliente> persistenciaDoCliente;
        ClienteDto clienteDto = new ClienteDto { Cep = "76806534", Nome = "Joao", Documento = "87755566644" };

        public CadastrarClienteTeste()
        {
            this.persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
        }

        [Fact]
        public async Task DeveCadastrarCliente()
        {
            //Arrange
            var cadastrarCliente = new CadastrarCliente(persistenciaDoCliente.Object);

            //Action
            await cadastrarCliente.Executar(clienteDto);

            //Assert
            persistenciaDoCliente.Verify(x => x.Salvar(It.IsAny<Cliente>()), Times.Once());
        }

        [Fact]
        public async Task DeveRetornarErroCasoClienteJaPossuirCadastro()
        {
            //Arrange
            persistenciaDoCliente.Setup(x => x.DoumentoJaCadastrado(It.IsAny<string>())).ReturnsAsync(true);
            var cadastrarCliente = new CadastrarCliente(persistenciaDoCliente.Object);

            //Action
            await cadastrarCliente.Executar(clienteDto);

            //Assert
            Assert.Equal("Cliente já possui cadastro!", cadastrarCliente.Erros.First().Value);
        }
    }
}
