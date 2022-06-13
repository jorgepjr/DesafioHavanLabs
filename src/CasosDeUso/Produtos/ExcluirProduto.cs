using Adaptadores.Interfaces;
using System.Threading.Tasks;

namespace CasosDeUso.Produtos
{
   public class ExcluirProduto : CasoDeUsoBase
    {
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public ExcluirProduto(IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task Executar(int produtoId)
        {
            var produto = await persistenciaDoProduto.BuscarPorId(produtoId);

            if(produto is null)
            {
                Erros.Add("Erro", "Cliente não encontrado!");
                return;
            }

            await persistenciaDoProduto.Excluir(produto);
        }
    }
}
