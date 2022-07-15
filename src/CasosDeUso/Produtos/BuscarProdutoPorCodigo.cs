using Dominio;
using Dominio.Interfaces;
using System;
using System.Threading.Tasks;

namespace CasosDeUso.Produtos
{
    public class BuscarProdutoPorCodigo : CasoDeUsoBase
    {
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public BuscarProdutoPorCodigo(IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task<Produto> Executar(string codigo)
        {
            Produto produto;

            try
            {
                produto = await persistenciaDoProduto.BuscarPorCodigo(codigo);
            }

            catch (Exception ex)
            {

                Erros.Add("Exception", ex.Message);
                return null;
            }

            if (produto is null)
            {
                Erros.Add("Erro", "Produto não encontrado!");
                return null;
            }

            return produto;
        }
    }
}
