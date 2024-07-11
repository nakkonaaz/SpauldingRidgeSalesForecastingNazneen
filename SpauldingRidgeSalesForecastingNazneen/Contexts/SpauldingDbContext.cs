using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpauldingRidgeSalesForecastingNazneen.Models;

namespace SpauldingRidgeSalesForecastingNazneen.Contexts;

public partial class SpauldingDbContext : DbContext
{
    public SpauldingDbContext()
    {
    }

    public SpauldingDbContext(DbContextOptions<SpauldingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersReturn> OrdersReturns { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6LP19S01\\SQLEXPRESS;Database=SpauldingRidge;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasColumnName("Postal_Code");
            entity.Property(e => e.Region).HasMaxLength(50);
            entity.Property(e => e.Segment).HasMaxLength(50);
            entity.Property(e => e.ShipMode).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<OrdersReturn>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Comments).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasMaxLength(50);
            entity.Property(e => e.ProductId).HasMaxLength(50);
            entity.Property(e => e.ProductName).IsUnicode(false);
            entity.Property(e => e.SubCategory).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
