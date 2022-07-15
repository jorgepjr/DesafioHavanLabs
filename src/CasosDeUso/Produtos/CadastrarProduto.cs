using CasosDeUso.Dtos;
using Dominio;
using Dominio.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso.Produtos
{
    public class CadastrarProduto : CasoDeUsoBase
    {
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public CadastrarProduto(IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task Executar(ProdutoDto produtoDto)
        {
            var produto = new Produto(produtoDto.Nome, produtoDto.Codigo, produtoDto.Preco, produtoDto.Quantidade);

            var resultado = await persistenciaDoProduto.BuscarPorCodigo(produtoDto.Codigo);

            if (resultado != null)
            {
                Erros.Add("Erro", $"Codigo: {produto.Codigo} já cadastrado!");
                return;
            }

            await persistenciaDoProduto.Salvar(produto);
        }
    }
}
