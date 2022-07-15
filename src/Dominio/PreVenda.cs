using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio
{
    public class PreVenda
    {
        protected PreVenda() { }

        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public List<ItemPreVenda> Itens { get; private set; } = new List<ItemPreVenda>();
        public DateTime DataDeRegistro { get; private set; }
        public Cliente Cliente { get; private set; }

        public static PreVenda Nova => new PreVenda();

        public PreVenda IncluirCliente(Cliente cliente)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
            DataDeRegistro = DateTime.Now.Date;

            return this;
        }

        public void AdicionarItens(Produto produto, int quantidade, decimal precoUnitario)
        {
            Itens.Add(new ItemPreVenda(produto, quantidade, precoUnitario));
        }

        public decimal CalcularTotal()
        {
           return Itens.Sum(x => x.PrecoUnitario * x.Quantidade);
        }
    }
}
