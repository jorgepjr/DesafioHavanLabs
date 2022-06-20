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
        private readonly IPersistenciaDoCliente persistenciaDoCliente;

        public CriarPreVenda(IPersistenciaDaPreVenda persistenciaDaPreVenda, IPersistenciaDoProduto persistenciaDoProduto, IPersistenciaDoCliente persistenciaDoCliente)
        {
            this.persistenciaDaPreVenda = persistenciaDaPreVenda;
            this.persistenciaDoProduto = persistenciaDoProduto;
            this.persistenciaDoCliente = persistenciaDoCliente;
        }

        public async Task<PreVenda> Executar(PreVendaDto preVendaDto, string documentoDoCliente)
        {
            var cliente = await persistenciaDoCliente.BuscarPorDocumento(documentoDoCliente);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente nao encontrado!");
            }

            var preVenda = new PreVenda(cliente);

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

                var itemPrevenda = new ItemPreVenda(produto, item.Quantidade, produto.Preco);
                preVenda.AdicionarItens(itemPrevenda);
            }

            await persistenciaDaPreVenda.Criar(preVenda);

            return preVenda;
        }

        private async Task AtualizarEstoque(int quantidade, Produto produto)
        {
            produto.Subtrair(quantidade, produto.Nome);
            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
