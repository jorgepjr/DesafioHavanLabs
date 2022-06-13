namespace Dominio
{
    public class Produto
    {
        protected Produto() { }

        public Produto(string nome, string codigo, decimal preco)
        {
            Nome = nome;
            Codigo = codigo;
            Preco = preco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public decimal Preco { get; private set; }

        public void AtualizarInformacoes(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
    }
}