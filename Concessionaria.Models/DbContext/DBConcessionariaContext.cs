﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Models.Models;

public partial class DBConcessionariaContext : DbContext
{
    public DBConcessionariaContext()
    {
    }

    public DBConcessionariaContext(DbContextOptions<DBConcessionariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Concessionária> Concessionária { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    public virtual DbSet<Veículo> Veículo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBConcessionaria;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D594664257AC12C3");
        });

        modelBuilder.Entity<Concessionária>(entity =>
        {
            entity.HasKey(e => e.IdConcessionária).HasName("PK__Concessi__3236807F83B26F20");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.IdVenda).HasName("PK__Venda__BC1DC6A97BB76FF9");

            entity.HasOne(d => d.ClienteIdClienteNavigation).WithMany(p => p.Venda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venda__Cliente_I__44FF419A");

            entity.HasOne(d => d.VeículoIdVeículoNavigation).WithMany(p => p.Venda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venda__Veículo_i__440B1D61");
        });

        modelBuilder.Entity<Veículo>(entity =>
        {
            entity.HasKey(e => e.IdVeículo).HasName("PK__Veículo__D68F0ADE44A3DA53");

            entity.HasOne(d => d.ConcessionáriaIdConcessionáriaNavigation).WithMany(p => p.Veículo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Veículo__Concess__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}