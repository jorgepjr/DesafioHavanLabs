using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Adaptadores.Persistencias
{
    public class PersistenciaDoProduto : IPersistenciaDoProduto
    {
        private readonly Contexto db;

        public PersistenciaDoProduto(Contexto db)
        {
            this.db = db;
        }

        public async Task Atualizar(Produto produto)
        {
            db.Update(produto);
            await db.SaveChangesAsync();
        }

        public async Task Excluir(Produto produto)
        {
            db.Remove(produto);
            await db.SaveChangesAsync();
        }

        public async Task<Produto> BuscarPorCodigo(string codigo)
        {
            var resultado = await db.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);

            return resultado;
        }

        public async Task Salvar(Produto produto)
        {
            await db.AddAsync(produto);
            await db.SaveChangesAsync();
        }

        public async Task<Produto> BuscarPorId(int produtoId)
        {
            return await db.Produtos.FirstOrDefaultAsync(x=>x.Id == produtoId);
        }
    }
}
