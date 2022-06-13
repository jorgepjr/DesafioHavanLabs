using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso.Produtos
{
    public class EditarProduto : CasoDeUsoBase
    {
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public EditarProduto(IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task Executar(ProdutoDto produtoDto, int produtoId)
        {
            var produto = await persistenciaDoProduto.BuscarPorId(produtoId);

            if (produto is null)
            {
                Erros.Add("Erro", "Produto não encontrado!");
                return;
            }

            if (produto.Codigo == produtoDto.Codigo)
            {
                Erros.Add("Erro", $"Codigo: {produto.Codigo} já existe!");
            }

            produto.AtualizarInformacoes(produtoDto.Codigo, produtoDto.Nome, produtoDto.Preco);

            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
