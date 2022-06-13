namespace Dominio
{
    public class Produto
    {
        protected Produto() { }

        public Produto(string nome, string codigo, decimal preco, int quantidade)
        {
            Nome = nome;
            Codigo = codigo;
            Preco = preco;
            Quantidade = quantidade;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }

        public void AtualizarInformacoes(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }

        public void Subtrair(int quantidade)
        {
            if (Quantidade >= quantidade)

                Quantidade -= quantidade;
        }
    }
}