using Adaptadores.Interfaces;
using Dominio;
using System.Threading.Tasks;

namespace Adaptadores.Persistencias
{
    public class PersistenciaDaPreVenda : IPersistenciaDaPreVenda
    {
        private readonly Contexto db;

        public PersistenciaDaPreVenda(Contexto db)
        {
            this.db = db;
        }

        public async Task Criar(PreVenda preVenda)
        {
            await db.AddAsync(preVenda);
            await db.SaveChangesAsync();
        }
    }
}
