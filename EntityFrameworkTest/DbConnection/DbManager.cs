using System;
using System.Collections.Generic;
using EntityFrameworkTest.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.DbConnection;

public partial class DbManager : DbContext
{
    public DbManager()
    {
    }

    public DbManager(DbContextOptions<DbManager> options)
        : base(options)
    {
    }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=194.67.105.79:5432;Database=weewsa_ef_db;Username=weewsa_ef_user;Password=00000");
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pk");

            entity.ToTable("ranks");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('countries_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_name_pk");

            entity.ToTable("users");

            entity.HasIndex(e => e.Id, "table_name_id_uindex").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('table_name_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");

            entity.HasOne(d => d.Place).WithMany(p => p.Users)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_countries_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}