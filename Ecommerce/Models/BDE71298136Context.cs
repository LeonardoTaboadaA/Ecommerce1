﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ecommerce.Models
{
    public partial class BDE71298136Context : DbContext
    {
        public BDE71298136Context()
        {
        }

        public BDE71298136Context(DbContextOptions<BDE71298136Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cupon> Cupons { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=bde71298136.database.windows.net;Initial Catalog=BDE71298136;Integrated Security=False; User ID=sa2;Password=E#71298136;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_IdCategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_IdCliente");

                entity.ToTable("Cliente");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cupon>(entity =>
            {
                entity.HasKey(e => e.IdCupon)
                    .HasName("PK_IdCupon");

                entity.ToTable("Cupon");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PK_IdDetalle_pedido");

                entity.ToTable("Detalle_pedido");

                entity.Property(e => e.IdDetallePedido).HasColumnName("IdDetalle_pedido");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdPedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdProducto");
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPedido)
                    .HasName("PK_IdEstado_pedido");

                entity.ToTable("Estado_pedido");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("IdEstado_pedido");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK_IdPedido");

                entity.ToTable("Pedido");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoPedido).HasColumnName("IdEstado_pedido");

                entity.Property(e => e.Igv).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCliente");

                entity.HasOne(d => d.IdCuponNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCupon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCupon");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdEstado_pedido");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK_IdProducto");

                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Imagen1).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCategoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
