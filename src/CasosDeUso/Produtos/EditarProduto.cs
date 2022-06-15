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

        public async Task Executar(EditarProdutoDto editarProdutoDto)
        {
            var produto = await persistenciaDoProduto.BuscarPorId(editarProdutoDto.ProdutoId);

            if (produto is null)
            {
                Erros.Add("Erro", "Produto não encontrado!");
                return;
            }

            produto.AtualizarInformacoes(editarProdutoDto.Nome, editarProdutoDto.Preco, editarProdutoDto.Estoque);

            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
