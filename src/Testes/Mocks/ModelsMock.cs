using CasosDeUso.Dtos;
using Dominio;

namespace Testes.Mocks
{
    public static class ModelsMock
    {
        public static Produto ProdutoMock => new Produto("Calça", "123", 30.00m, 12);

        public static EditarProdutoDto EditarProdutoDtoMock => new EditarProdutoDto {ProdutoId = 1, Nome = "Brinquedo", Preco = 40, Estoque = 4 };

        public static Cliente ClienteMock => new Cliente("Joao", "87755566644", "76806-534");

        public static AtualizarClienteDto AtualizarClienteDtoMock => new AtualizarClienteDto {ClienteId = 1, Cep = "76806-534", Nome = "Pedro" };

    }
}
