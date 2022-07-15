using CasosDeUso.Dtos;
using CasosDeUso.Interfaces;
using Dominio;
using Dominio.Interfaces;
using System;
using System.Threading.Tasks;

namespace CasosDeUso.Vendas
{
    public class CriarPreVenda : CasoDeUsoBase
    {
        private readonly IPersistenciaDaPreVenda persistenciaDaPreVenda;
        private readonly IPersistenciaDoProduto persistenciaDoProduto;
        private readonly ICadastroDoCliente cadastroDoCliente;

        public CriarPreVenda(IPersistenciaDaPreVenda persistenciaDaPreVenda, IPersistenciaDoProduto persistenciaDoProduto, ICadastroDoCliente cadastroDoCliente)
        {
            this.persistenciaDaPreVenda = persistenciaDaPreVenda;
            this.persistenciaDoProduto = persistenciaDoProduto;
            this.cadastroDoCliente = cadastroDoCliente;
        }

        public async Task<PreVenda> Executar(PreVendaDto preVendaDto)
        {
            var cliente = await cadastroDoCliente.BuscarPorDocumento(preVendaDto.DocumentoDoCliente);

            if (cliente is null)
            {
                Erros.Add("Erro", "Cliente nao encontrado!");
            }

            var preVenda = new PreVenda(cliente);

            foreach (var item in preVendaDto.Itens)
            {
                var produto = await persistenciaDoProduto.BuscarPorCodigo(item.CodigoDoProduto);

                if (produto is null)
                {
                    Erros.Add("Erro", "Produto não existe!");
                    return null;
                }

                try
                {
                    preVenda.AdicionarItem(produto, item.Quantidade, produto.Preco);
                    await AtualizarEstoque(item.Quantidade, produto);
                }
                catch (Exception ex)
                {

                    Erros.Add("Erro", ex.Message); ;
                }
            }

            try
            {
                await persistenciaDaPreVenda.Criar(preVenda);
                return preVenda;
            }

            catch (Exception ex)
            {
                Erros.Add("Erro estoque", ex.Message);
                return null;
            }
        }

        private async Task AtualizarEstoque(int quantidade, Produto produto)
        {
            produto.RetirarDoEstoque(quantidade, produto.Nome);
            await persistenciaDoProduto.Atualizar(produto);
        }
    }
}
