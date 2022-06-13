namespace Dominio
{
    public class ItemPreVenda
    {
        protected ItemPreVenda() { }

        public ItemPreVenda(Produto produto, int quantidade, decimal precoUnitario, decimal total)
        {
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Total = total;
        }

        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal Total { get; private set; }
    }
}
