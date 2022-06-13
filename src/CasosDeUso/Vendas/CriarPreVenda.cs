using Adaptadores.Dtos;
using Adaptadores.Interfaces;
using Dominio;
using System.Threading.Tasks;

namespace CasosDeUso.Vendas
{
    public class CriarPreVenda
    {
        private readonly IPersistenciaDaPreVenda persistenciaDaPreVenda;
        private readonly IPersistenciaDoCliente persistenciaDoCliente;
        private readonly IPersistenciaDoProduto persistenciaDoProduto;

        public CriarPreVenda(IPersistenciaDaPreVenda persistenciaDaPreVenda, IPersistenciaDoCliente persistenciaDoCliente, IPersistenciaDoProduto persistenciaDoProduto)
        {
            this.persistenciaDaPreVenda = persistenciaDaPreVenda;
            this.persistenciaDoCliente = persistenciaDoCliente;
            this.persistenciaDoProduto = persistenciaDoProduto;
        }

        public async Task Executar(PreVendaDto preVendaDto)
        {
            var cliente = await persistenciaDoCliente.BuscarPorDocumento(preVendaDto.DocumentoDoCliente);

            var preVenda = new PreVenda(cliente);

            foreach (var item in preVendaDto.Itens)
            {
                var produto = await persistenciaDoProduto.BuscarPorCodigo(item.CodigoDoProduto);

                var total = item.Quantidade * produto.Preco;

                var itemPrevenda = new ItemPreVenda(produto, item.Quantidade, produto.Preco, total);

                preVenda.AdicionarItens(itemPrevenda);
            }

            await persistenciaDaPreVenda.Criar(preVenda);
        }
    }
}
