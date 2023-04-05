using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TRPO1.Entities;

namespace TRPO1.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Num> Nums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;port=5433;User Id=postgres;Password=root;Database=trpo");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Num>(entity =>
        {
            entity
                .ToTable("nums");

            entity.Property(e => e.FirstNumber).HasColumnName("firstNumber");
            entity.Property(e => e.FirstNumberNotation).HasColumnName("firstNumberNotation");
            entity.Property(e => e.Operation).HasColumnName("operation");
            entity.Property(e => e.SecondNumber).HasColumnName("secondNumber");
            entity.Property(e => e.SecondNumberNotation).HasColumnName("secondNumberNotation");
            entity.Property(e => e.id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
