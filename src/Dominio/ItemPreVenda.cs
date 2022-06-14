namespace Dominio
{
    public class ItemPreVenda
    {
        protected ItemPreVenda() { }

        public ItemPreVenda(Produto produto, int quantidade, decimal precoUnitario)
        {
            Produto = produto;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public Produto Produto { get; private set; }
    }
}
