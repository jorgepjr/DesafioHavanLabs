using System;

namespace Dominio
{
    public class Produto
    {
        protected Produto() { }

        public Produto(string nome, string codigo, decimal preco, int estoque)
        {
            Nome = nome;
            Codigo = codigo;
            Preco = preco;
            Estoque = estoque;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        public void AtualizarInformacoes(string nome, decimal preco, int estoque)
        {
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }

        public void Subtrair(int quantidade, string nomeDoProduto)
        {
            if (Estoque == 0 || Estoque < quantidade)
            {
                throw new Exception($"Produto: [{nomeDoProduto}] indisponível!");
            }

            Estoque -= quantidade;
        }
    }
}