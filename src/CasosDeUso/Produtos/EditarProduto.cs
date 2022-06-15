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

            if (produto.Codigo == editarProdutoDto.Codigo)
            {
                Erros.Add("Erro", $"Codigo: {editarProdutoDto.Codigo} já existe!");
            }

            produto.AtualizarInformacoes(editarProdutoDto.Codigo, editarProdutoDto.Nome, editarProdutoDto.Preco);

            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
