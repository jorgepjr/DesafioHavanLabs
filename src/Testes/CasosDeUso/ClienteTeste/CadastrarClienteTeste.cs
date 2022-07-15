using CasosDeUso.Clientes;
using CasosDeUso.Dtos;
using Dominio;
using Dominio.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Testes.CasosDeUso.ClienteTeste
{
    public class CadastrarClienteTeste
    {
        ClienteDto clienteDto = new ClienteDto { Cep = "76806534", Nome = "Joao", Documento = "87755566644" };

        [Fact]
        public async Task DeveCadastrarCliente()
        {
            //Arrange
            var persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            var cadastrarCliente = new CadastroDoCliente(persistenciaDoCliente.Object);

            //Action
            await cadastrarCliente.Registrar(clienteDto);

            //Assert
            persistenciaDoCliente.Verify(x => x.Salvar(It.IsAny<Cliente>()), Times.Once());
        }

        [Fact]
        public async Task DeveRetornarErroCasoClienteJaPossuirCadastro()
        {
            //Arrange
            var persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            persistenciaDoCliente.Setup(x => x.DoumentoJaCadastrado(It.IsAny<string>())).ReturnsAsync(true);
            var cadastrarCliente = new CadastroDoCliente(persistenciaDoCliente.Object);

            //Action
            await cadastrarCliente.Registrar(clienteDto);

            //Assert
            Assert.Equal($"Documento nª: {clienteDto.Documento} já cadastrado!", cadastrarCliente.MensagemDoErro);
        }
    }
}
