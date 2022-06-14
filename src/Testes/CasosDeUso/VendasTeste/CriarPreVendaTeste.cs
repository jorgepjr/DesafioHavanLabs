using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using CasosDeUso.Vendas;
using Dominio;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.VendasTeste
{
    public class CriarPreVendaTeste
    {
        Produto produto = ModelsMock.ProdutoMock;

        Mock<IPersistenciaDoCliente> persistenciaDoClinte = new Mock<IPersistenciaDoCliente>();
        Mock<IPersistenciaDoProduto> persistenciaDoProduto = new Mock<IPersistenciaDoProduto>();
        Mock<IPersistenciaDaPreVenda> persistenciaDaPreVenda = new Mock<IPersistenciaDaPreVenda>();

        public CriarPreVendaTeste()
        {
            persistenciaDoClinte.Setup(x => x.BuscarPorDocumento(It.IsAny<string>())).ReturnsAsync(ModelsMock.ClienteMock);
            persistenciaDoProduto.Setup(x => x.BuscarPorCodigo(It.IsAny<string>())).ReturnsAsync(produto);

        }

        [Fact]
        public async Task DeveCriarUmaPreVenda()
        {
            //Arrange
            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = "2", Quantidade = 5 };
            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };
            var preVendaDto = new PreVendaDto { DocumentoDoCliente = "44445055", Itens = itens };
            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto, It.IsAny<int>());

            //Assert
            persistenciaDaPreVenda.Verify(x => x.Criar(It.IsAny<PreVenda>()), Times.Once());
        }

        [Fact]
        public async Task DeveAtualizarEstoqueAoAdicionarItemNaPreVenda()
        {
            //Arrange
            var clienteId = 45;
            var estoque = 7;

            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = "2", Quantidade = 5 };
            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };
            var preVendaDto = new PreVendaDto { DocumentoDoCliente = "44445055", Itens = itens };
            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto, clienteId);

            //Assert
            Assert.Equal(estoque, produto.Quantidade);
        }

        [Fact]
        public async Task DeveCalcularTotal()
        {
            //Arrange
            var clienteId = 45;
            var estoque = 7;

            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = "2", Quantidade = 5 };
            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };
            var preVendaDto = new PreVendaDto { DocumentoDoCliente = "44445055", Itens = itens };
            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto, clienteId);

            //Assert
            Assert.Equal(estoque, produto.Quantidade);
        }
    }
}
