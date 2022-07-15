using Dominio;
using System;
using Testes.Mocks;
using WebApi.Factories;
using Xunit;

namespace Testes
{
    public class PreVendaFactoryTeste
    {
        [Fact]
        public void DeveCriarVendaDto()
        {
            //Arrange
            var quantidade = 2;
            var cliente = ModelsMock.ClienteMock;
            var produto = ModelsMock.ProdutoMock;
            var preVenda = new  PreVenda(cliente);
            preVenda.AdicionarItem(produto, quantidade, produto.Preco);

            //Action
            var vendaDto = PreVendaFactory.Criar("88896655544", preVenda);

            //Assert
            Assert.Equal("88896655544", vendaDto.Cliente);
            Assert.Equal("123", vendaDto.Itens[0].CodigoDoProduto);
            Assert.Equal(30.00m, vendaDto.Itens[0].PrecoUnitario);
            Assert.Equal(2, vendaDto.Itens[0].Quantidade);
            Assert.Equal(60.00m, vendaDto.Total);
            Assert.Equal(DateTime.Now.Date, preVenda.DataDeRegistro.Date);
        }
    }
}
