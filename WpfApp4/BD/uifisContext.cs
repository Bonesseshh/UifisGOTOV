using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp4
{
    public partial class uifisContext : DbContext
    {
        public uifisContext()
        {
            Database.EnsureCreated();
        }

        public uifisContext(DbContextOptions<uifisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<TypeTransport> TypeTransports { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=uifis;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.IdRoute);

                entity.Property(e => e.Route1)
                    .HasMaxLength(50)
                    .HasColumnName("Route");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.IdTransports);

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.IdRoute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transports_Routes");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transports_TypeTransport");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transports_Users");
            });

            modelBuilder.Entity<TypeTransport>(entity =>
            {
                entity.HasKey(e => e.IdTransport);

                entity.ToTable("TypeTransport");

                entity.Property(e => e.NameTransport).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.SecondName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
