﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Model.Models;

public partial class ConcessionariaDBContext : DbContext
{
    public ConcessionariaDBContext()
    {
    }

    public ConcessionariaDBContext(DbContextOptions<ConcessionariaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Concessionaria> Concessionaria { get; set; }

    public virtual DbSet<Veiculo> Veiculo { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PTS766H\\SQLEXPRESS;Initial Catalog=ConcessionariaDB;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642CBCFD740");

            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Concessionaria>(entity =>
        {
            entity.HasKey(e => e.IdConcessionaria).HasName("PK__Concessi__ED455BC12ACAEEF1");

            entity.Property(e => e.IdConcessionaria).HasColumnName("idConcessionaria");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.IdVeiculo).HasName("PK__Veiculo__8178EBE8B8488838");

            entity.Property(e => e.IdVeiculo).HasColumnName("idVeiculo");
            entity.Property(e => e.ConcessionariaIdConcessionaria).HasColumnName("Concessionaria_idConcessionaria");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TipoVeiculo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ConcessionariaIdConcessionariaNavigation).WithMany(p => p.Veiculo)
                .HasForeignKey(d => d.ConcessionariaIdConcessionaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Veiculo__Concess__4D94879B");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.IdVenda).HasName("PK__Venda__BC1DC6A9E1C845B1");

            entity.Property(e => e.ClienteIdCliente).HasColumnName("Cliente_IdCliente");
            entity.Property(e => e.DataVenda).HasColumnType("date");
            entity.Property(e => e.VeiculoIdVeiculo).HasColumnName("Veiculo_idVeiculo");

            entity.HasOne(d => d.ClienteIdClienteNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.ClienteIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venda__Cliente_I__5165187F");

            entity.HasOne(d => d.VeiculoIdVeiculoNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.VeiculoIdVeiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venda__Veiculo_i__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}