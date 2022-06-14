﻿using Adaptadores.Dtos;
using Dominio;
using System.Collections.Generic;
using System.Linq;

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
                Total = preVenda.CalcularTotal()
            };
        }

        public static List<ItemVendaDto> ListaDeItens(List<ItemPreVenda> itens)
        {
            return itens.Select(x => new ItemVendaDto
            {
                CodigoDoProduto = x.Produto?.Codigo,
                Quantidade = x.Quantidade,
                PrecoUnitario =  x.PrecoUnitario

            }).ToList();
        }
    }
}
