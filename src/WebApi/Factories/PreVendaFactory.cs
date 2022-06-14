using Adaptadores.Dtos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Factories
{
    public static class PreVendaFactory
    {
        public static VendaDto Criar(string cliente, PreVenda preVenda)
        {
            var itens = ListaDeItens(preVenda.Itens);

            return new VendaDto
            {
                Cliente = cliente,
                Itens = itens,
                Total = itens.Sum(x=>x.PrecoUnitario)
                
            };
        }

        public static List<ItemVendaDto> ListaDeItens(List<ItemPreVenda> itens)
        {
            return itens.Select(x => new ItemVendaDto
            {
                CodigoDoProduto = x.Produto.Codigo,
                Quantidade = x.Quantidade,
                PrecoUnitario =  x.PrecoUnitario

            }).ToList();
        }
    }
}
