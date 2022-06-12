using Adaptadores.Interfaces;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Adaptadores.Persistencias
{
    public class PersistenciaDoCliente : IPersistenciaDoCliente
    {
        private readonly Contexto db;

        public PersistenciaDoCliente(Contexto db)
        {
            this.db = db;
        }

        public async Task Cadastrar(Cliente cliente)
        {
            await db.AddAsync(cliente);
            await db.SaveChangesAsync();
        }

        public async Task<bool> JaPossuiCadastro(string documento)
        {
            var resultado = await db.Clientes.AnyAsync(x => x.Documento == documento);

            return resultado;
        }

        public async Task Excluir(Cliente cliente)
        {
            db.Remove(cliente);
            await db.SaveChangesAsync();
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
