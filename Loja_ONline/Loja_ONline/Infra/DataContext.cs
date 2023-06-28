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

            modelBuilder.Entity<PerfilUsuario>(x =>
            {
                x.ToTable("PerfilUsuario");
                x.HasKey(x => x.IdPerfil);
            });

            modelBuilder.Entity<Usuarios>(x =>
            {
                x.ToTable("Usuarios");
                x.HasKey(x => x.IdUsuario);
                x.Property(x => x.Nome).HasColumnType("varchar(80)").IsRequired();
                x.Property(x => x.DataNascimento).HasColumnType("Datetime").IsRequired();
                x.Property(x => x.CPF).HasColumnType("varchar(15)").IsRequired();
                x.Property(x => x.Sexo).HasColumnType("char").IsRequired();
                x.Property(x => x.Login).HasColumnType("varchar(50)").IsRequired();
                x.Property(x => x.Senha).HasColumnType("varchar(20)").IsRequired();
                x.HasOne(x => x.PerfilUsuario).WithMany().HasForeignKey(x => x.IdPerfil);
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
                x.HasOne(x => x.Usuarios).WithMany().HasForeignKey(x => x.IdUsuario);
            });

            modelBuilder.Entity<Vendas>(x =>
            {
                x.ToTable("Vendas");
                x.HasKey(x => x.IdVenda);
                x.Property(x => x.DataVenda).HasColumnType("Datetime").IsRequired();
                x.Property(x => x.QuantidadeComprada).HasColumnType("int").IsRequired();
                x.Property(x => x.ValorPago).HasColumnType("decimal(10,2)").IsRequired();
                x.HasOne(x => x.Produtos).WithMany().HasForeignKey(x => x.IdProduto);
            });
        }

        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produtos> Products { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
    }
}
