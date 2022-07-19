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
        public DbSet<PreVenda> PreVendas { get; set; }
        public DbSet<ItemPreVenda> ItensPreVenda { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cliente>(cliente =>
        //    {
        //        cliente.OwnsOne(y => y.Documento, documento =>
        //        {
        //            documento.Property(y => y.Valor)
        //            .IsRequired()
        //            .HasColumnName("Documento")
        //            .HasColumnType("varchar(11)");
        //        });

        //        cliente.OwnsOne(y => y.Cep, documento =>
        //        {
        //            documento.Property(y => y.Numero)
        //            .IsRequired()
        //            .HasColumnName("Cep")
        //            .HasColumnType("varchar(11)");
        //        });
        //    });
        //}
    }
}
