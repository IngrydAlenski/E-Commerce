using System;
using System.Collections.Generic;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Context;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE25-S28\\SQLEXPRESS;initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D59466427852337F");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Email, "UQ__Cliente__A9D10534EFA0581A").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("PK__ItemPedi__F77088BAAA4003EB");

            entity.ToTable("ItemPedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemPedid__IdPed__19DFD96B");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemPedid__IdPro__1AD3FDA4");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.IdPagamento).HasName("PK__Pagament__D474651EB6BB76A6");

            entity.ToTable("Pagamento");

            entity.Property(e => e.DataPagamento).HasColumnType("datetime");
            entity.Property(e => e.FormaPagamento)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StatusPagamento)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagamento__IdPed__1DB06A4F");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC3CDC62B70");

            entity.ToTable("Pedido");

            entity.Property(e => e.StatusPedido)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("VAlorTotal");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__IdClient__151B244E");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C235FDE712C");

            entity.ToTable("Produto");

            entity.Property(e => e.CategoriaProduto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoProduto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImagemProduto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 6)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
