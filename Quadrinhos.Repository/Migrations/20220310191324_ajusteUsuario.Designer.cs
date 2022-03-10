﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quadrinhos.Repository.Data;

namespace Quadrinhos.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220310191324_ajusteUsuario")]
    partial class ajusteUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Quadrinhos.Domain.Models.Quadrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("publicacao");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<string>("Escritor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("escritor");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco");

                    b.Property<int>("QtdeEstoque")
                        .HasColumnType("int")
                        .HasColumnName("estoque");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("titulo");

                    b.HasKey("Id")
                        .HasName("PK_quadrinho");

                    b.ToTable("quadrinho");
                });

            modelBuilder.Entity("Quadrinhos.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("senha");

                    b.HasKey("Id")
                        .HasName("PK_usuario");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Quadrinhos.Domain.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_inclusao");

                    b.Property<int>("Qtde")
                        .HasColumnType("int")
                        .HasColumnName("qtde");

                    b.Property<int>("QuadrinhoId")
                        .HasColumnType("int")
                        .HasColumnName("quadrinho_id");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id")
                        .HasName("PK_venda");

                    b.HasIndex("QuadrinhoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("venda");
                });

            modelBuilder.Entity("Quadrinhos.Domain.Models.Venda", b =>
                {
                    b.HasOne("Quadrinhos.Domain.Models.Quadrinho", "Quadrinho")
                        .WithMany("Vendas")
                        .HasForeignKey("QuadrinhoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quadrinhos.Domain.Models.Usuario", "Usuario")
                        .WithMany("Vendas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Quadrinho");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Quadrinhos.Domain.Models.Quadrinho", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("Quadrinhos.Domain.Models.Usuario", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}