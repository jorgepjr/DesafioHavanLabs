using Adaptadores;
using Bogus;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Testes.Mocks
{
    public abstract class DatabaseMock
    {
        readonly Contexto contextoMock;
        readonly DbContextOptions<Contexto> options;

        protected DatabaseMock()
        {
            this.options = new DbContextOptionsBuilder<Contexto>().UseInMemoryDatabase("Contexto").Options;
            contextoMock = new Contexto(options);
            CriarProdutoMock();
            CadastrarClienteMock();
        }

        protected void CriarProdutoMock()
        {
            var produto = new Faker<Produto>("pt_BR")
               .CustomInstantiator(x => new Produto(x.Commerce.Product(), x.Random.Int(1, 10).ToString(), x.Random.Int(1, 100), 20))
               .Generate(10);

            contextoMock.Produtos.AddRange(produto);
            contextoMock.SaveChanges();
        }

        protected Produto BuscarProdutoMock(int id)
        {
            var produto = contextoMock.Produtos.FirstOrDefault(x => x.Id == id);

            return produto;
        }

        protected Produto BuscarProdutoPorCodigoMock(string codigo)
        {
            var produto = contextoMock.Produtos.FirstOrDefault(x => x.Codigo == codigo);

            return produto;
        }

        protected IEnumerable<Produto> ListaDeProdutosMock()
        {
            var produtos = contextoMock.Produtos.ToList();

            return produtos;
        }

        protected Cliente BuscarClienteMock(int id)
        {
            var cliente = contextoMock.Clientes.FirstOrDefault(x => x.Id == id);

            return cliente;
        }

        protected Cliente BuscarClientePorDocumentoMock(string documento)
        {
            var cliente = contextoMock.Clientes.FirstOrDefault(x => x.Documento == documento);

            return cliente;
        }

        protected void CadastrarClienteMock()
        {
            var clienteFake = new Faker<Cliente>("pt_BR")
               .CustomInstantiator(x => new Cliente(x.Name.FullName(), x.Random.Int(1, 10).ToString(), x.Address.StreetAddress()))
               .Generate(10);

            contextoMock.Clientes.AddRange(clienteFake);
            contextoMock.SaveChanges();
        }
    }
}
