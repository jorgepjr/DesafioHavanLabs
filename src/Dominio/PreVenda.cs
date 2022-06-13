using System;
using System.Collections.Generic;

namespace Dominio
{
    public class PreVenda
    {
        protected PreVenda() { }

        public PreVenda(Cliente cliente)
        {
            Cliente = cliente;
            DataDeRegistro = DateTime.Now.Date;
        }

        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<ItemPreVenda> Itens { get; private set; } = new List<ItemPreVenda>();
        public DateTime DataDeRegistro { get; private set; }

        public void AdicionarItens(ItemPreVenda itemPreVenda)
        {
            Itens.Add(itemPreVenda);
        }
    }
}
