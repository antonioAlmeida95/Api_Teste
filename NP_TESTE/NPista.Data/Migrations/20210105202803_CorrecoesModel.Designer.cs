﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NPista.Data.EFCore.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NPista.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210105202803_CorrecoesModel")]
    partial class CorrecoesModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseSerialColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("NPista.Core.Models.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Bandeira")
                        .HasColumnType("text");

                    b.Property<string>("Cvv")
                        .HasColumnType("text");

                    b.Property<string>("DataExpiracao")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Titular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("NPista.Core.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<int>("CartaoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 1, 5, 17, 28, 2, 870, DateTimeKind.Local).AddTicks(2572));

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("QtdeComprada")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("NPista.Core.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseSerialColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QtdeEstoque")
                        .HasColumnType("integer");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("NPista.Core.Models.Compra", b =>
                {
                    b.HasOne("NPista.Core.Models.Cartao", "Cartao")
                        .WithMany("Compras")
                        .HasForeignKey("CartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NPista.Core.Models.Produto", "Produto")
                        .WithMany("Compras")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("NPista.Core.Models.Cartao", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("NPista.Core.Models.Produto", b =>
                {
                    b.Navigation("Compras");
                });
#pragma warning restore 612, 618
        }
    }
}
