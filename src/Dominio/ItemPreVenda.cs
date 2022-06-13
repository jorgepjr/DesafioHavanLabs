namespace Dominio
{
    public class ItemPreVenda
    {
        protected ItemPreVenda() { }

        public ItemPreVenda(int produtoId, int quantidade, decimal precoUnitario, decimal total)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Total = total;
        }

        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Total { get; private set; }
        public Produto Produto { get; private set; }
    }
}
