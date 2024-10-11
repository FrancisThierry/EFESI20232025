using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace TDScaffoldOneToMany.Models
{
    public partial class OneToManyContext : DbContext
    {
        public OneToManyContext()
        {
        }

        public OneToManyContext(DbContextOptions<OneToManyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Piece> Pieces { get; set; } = null!;
        public virtual DbSet<Voiture> Voitures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlite("Filename= C:\\data\\OneToMany.db").LogTo(Console.WriteLine, LogLevel.Information); // Affiche les requêtes SQL dans la console
                optionsBuilder.UseLazyLoadingProxies().UseSqlite("Filename= C:\\data\\OneToMany.db").LogTo(Console.WriteLine, LogLevel.Information); // Affiche les requêtes SQL dans la console

                

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piece>(entity =>
            {
                entity.ToTable("Piece");

                entity.Property(e => e.FkVoitureId).HasColumnName("FK_voiture_id");

                entity.HasOne(d => d.FkVoiture)
                    .WithMany(p => p.Pieces)
                    .HasForeignKey(d => d.FkVoitureId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Voiture>(entity =>
            {
                entity.ToTable("Voiture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
