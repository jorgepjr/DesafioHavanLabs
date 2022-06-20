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
    public class CadastrarClienteTeste
    {
        ClienteDto clienteDto = new ClienteDto { Cep = "76806534", Nome = "Joao", Documento = "87755566644" };

        [Fact]
        public async Task DeveCadastrarCliente()
        {
            //Arrange
            var persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
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
            var persistenciaDoCliente = new Mock<IPersistenciaDoCliente>();
            persistenciaDoCliente.Setup(x => x.DoumentoJaCadastrado(It.IsAny<string>())).ReturnsAsync(true);
            var cadastrarCliente = new CadastrarCliente(persistenciaDoCliente.Object);

            //Action
            await cadastrarCliente.Executar(clienteDto);

            //Assert
            Assert.Equal($"Documento nª: {clienteDto.Documento} já cadastrado!", cadastrarCliente.MensagemDoErro);
        }
    }
}
