using Loja_ONline.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja_ONline.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            modelBuilder.Entity<Usuarios>(x =>
            {
                x.ToTable("Usuarios");
                x.HasKey(x => x.IdUsuario);
                x.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
                x.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
                x.Property(x => x.Sexo).HasColumnType("CHAR").IsRequired();
                x.Property(x => x.Login).HasColumnType("varchar(20)").IsRequired();
                x.Property(x => x.Senha).HasColumnType("varchar(20)").IsRequired();
            });

            modelBuilder.Entity<Vendedores>(x =>
            {
                x.ToTable("Vendedores");
                x.HasKey(x => x.IdVendedor);
                x.Property(x => x.QuantidadeVendas).HasColumnType("int").IsRequired();
                x.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
                x.HasMany(x => x.Produtos).WithOne().HasForeignKey(x => x.IdProduto);
            });

            modelBuilder.Entity<Produtos>(x =>
            {
                x.ToTable("Produtos");
                x.HasKey(x => x.IdProduto);
                x.Property(x => x.Imagem).HasColumnType("varchar(250)").IsRequired();
                x.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
                x.Property(x => x.Preco).HasColumnType("decimal(10,2)").IsRequired();
                x.Property(x => x.DataCadastro).HasColumnType("date").IsRequired();
                x.Property(x => x.QuantidadeEstoque).HasColumnType("int").IsRequired();
                x.Property(x => x.Descricao).HasColumnType("varchar(250)").IsRequired();
                x.Property(x => x.Status).HasColumnType("int").IsRequired();
                x.HasOne(x => x.Vendedores).WithMany().HasForeignKey(x => x.IdVendedor);
            });
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Vendedores> Vendedor { get; set; }
        public DbSet<Produtos> Products { get; set; }
    }
}
