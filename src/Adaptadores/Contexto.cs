using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Adaptadores
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
