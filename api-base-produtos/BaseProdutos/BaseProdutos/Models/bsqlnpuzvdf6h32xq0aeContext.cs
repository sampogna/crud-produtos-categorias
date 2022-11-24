using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseProdutos.Models
{
    public partial class bsqlnpuzvdf6h32xq0aeContext : DbContext
    {
        public bsqlnpuzvdf6h32xq0aeContext()
        {
        }

        public bsqlnpuzvdf6h32xq0aeContext(DbContextOptions<bsqlnpuzvdf6h32xq0aeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Produto> Produto { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=bsqlnpuzvdf6h32xq0ae-mysql.services.clever-cloud.com;user=u5lcfw91othege9j;password=UNU11Y6WZdwgcYy7o0c5;database=bsqlnpuzvdf6h32xq0ae", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.ID_Categoria)
                    .HasName("PRIMARY");

                entity.Property(e => e.ID_Categoria).ValueGeneratedNever();

                entity.Property(e => e.Dsc_Categoria).HasMaxLength(255);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.ID_Produto)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ID_Categoria_Produto, "ID_Categoria_Produto");

                entity.Property(e => e.ID_Produto).ValueGeneratedNever();

                entity.Property(e => e.Dsc_Produto).HasMaxLength(100);

                entity.Property(e => e.Nome_Produto).HasMaxLength(100);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.ID_Categoria_Produto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produto_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
