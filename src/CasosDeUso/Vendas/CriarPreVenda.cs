using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using Dominio;
using System;
using System.Threading.Tasks;

namespace CasosDeUso.Vendas
{
    public class CriarPreVenda : CasoDeUsoBase
    {
        private readonly IPersistenciaDaPreVenda persistenciaDaPreVenda;
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public CriarPreVenda(IPersistenciaDaPreVenda persistenciaDaPreVenda, IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDaPreVenda = persistenciaDaPreVenda;
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task<PreVenda> Executar(PreVendaDto preVendaDto, int? clienteId)
        {
            if (clienteId is null)
            {
                Erros.Add("Erro", "ClienteId inválido!");
            }

            var preVenda = new PreVenda(clienteId.Value);

            foreach (var item in preVendaDto.Itens)
            {
                var produto = await persistenciaDoProduto.BuscarPorCodigo(item.CodigoDoProduto);

                try
                {
                    await AtualizarEstoque(item.Quantidade, produto);

                }
                catch (Exception ex)
                {
                    Erros.Add("Erro estoque", ex.Message);
                    return null;
                }

                var itemPrevenda = new ItemPreVenda(produto.Id, item.Quantidade, produto.Preco);
                preVenda.AdicionarItens(itemPrevenda);
            }

            await persistenciaDaPreVenda.Criar(preVenda);

            return preVenda;
        }

        private async Task AtualizarEstoque(int quantidade, Produto produto)
        {
            produto.Subtrair(quantidade);
            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
