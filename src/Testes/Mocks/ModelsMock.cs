using Adaptadores.Dtos;
using Dominio;

namespace Testes.Mocks
{
    public static class ModelsMock
    {
        public static Produto ProdutoMock => new Produto("Calça", "123", 30.00m, 12);


        public static ProdutoDto ProdutoDtoMock => new ProdutoDto { Codigo = "33344", Nome = "Brinquedo", Preco = 40, Quantidade = 4 };

        public static Cliente ClienteMock => new Cliente("Joao", "87755566644", "76806534");
    }
}
