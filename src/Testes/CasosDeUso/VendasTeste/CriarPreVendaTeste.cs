using CasosDeUso.Dtos;
using CasosDeUso.Vendas;
using Dominio;
using Dominio.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testes.Mocks;
using Xunit;

namespace Testes.CasosDeUso.VendasTeste
{
    public class CriarPreVendaTeste : PersistenciasMock
    {
        [Fact]
        public async Task DeveCriarUmaPreVenda()
        {
            //Arrange
            var documento = "8";
            var codigo = "10";
            var persistenciaDoCliente = PersistenciaDoClienteBuscarDocumentoMock(documento);

            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var produto = await persistenciaDoProduto.Object.BuscarPorCodigo(codigo);
            var persistenciaDaPreVenda = new Mock<IPersistenciaDaPreVenda>();

            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = codigo, Quantidade = 5 };
            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };
            var preVendaDto = new PreVendaDto { DocumentoDoCliente = documento, Itens = itens };

            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object, persistenciaDoCliente.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto);

            //Assert
            persistenciaDaPreVenda.Verify(x => x.Criar(It.IsAny<PreVenda>()), Times.Once());
        }

        [Fact]
        public async Task DeveAtualizarEstoqueAoAdicionarItemNaPreVenda()
        {
            //Arrange
            var estoque = 95;
            var documento = "6";
            var codigo = "10";

            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var produto = await persistenciaDoProduto.Object.BuscarPorCodigo(codigo);

            var persistenciaDoCliente = PersistenciaDoClienteBuscarDocumentoMock(documento);
            var persistenciaDaPreVenda = new Mock<IPersistenciaDaPreVenda>();

            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = codigo, Quantidade = 5 };
            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };
            var preVendaDto = new PreVendaDto { DocumentoDoCliente = documento, Itens = itens };

            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object, persistenciaDoCliente.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto);

            //Assert
            Assert.Equal(estoque, produto.Estoque);
        }

        [Fact]
        public async Task DeveRetornarErroCasoEstoqueTenhaAcabado()
        {
            //Arrange
            var documento = "6";
            var codigo = "10";
            var persistenciaDoCliente = PersistenciaDoClienteBuscarDocumentoMock(documento);
            var persistenciaDoProduto = PersistenciaDoProdutoBuscarPorCodigoMock(codigo);
            var produto = await persistenciaDoProduto.Object.BuscarPorCodigo(codigo);

            var persistenciaDaPreVenda = new Mock<IPersistenciaDaPreVenda>();

            var itemDaPreVendaDto = new ItemPreVendaDto { CodigoDoProduto = produto.Codigo, Quantidade =101 };

            var itens = new List<ItemPreVendaDto> { itemDaPreVendaDto };

            var preVendaDto = new PreVendaDto { DocumentoDoCliente = documento, Itens = itens };

            var criarPreVenda = new CriarPreVenda(persistenciaDaPreVenda.Object, persistenciaDoProduto.Object, persistenciaDoCliente.Object);

            //Action
            await criarPreVenda.Executar(preVendaDto);


            //Assert
            Assert.Equal($"Produto: [{produto.Nome}] indisponível!", criarPreVenda.Erros.First().Value);
        }
    }
}
