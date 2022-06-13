using System;
using System.Collections.Generic;

namespace Dominio
{
    public class PreVenda
    {
        protected PreVenda() { }

        public PreVenda(Cliente cliente, List<ItemPreVenda> itens)
        {
            Cliente = cliente;
            Itens = itens;
            DataDeRegistro = DateTime.Now.Date;
        }

        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<ItemPreVenda> Itens { get; private set; }
        public DateTime DataDeRegistro { get; private set; }
    }
}
