﻿// <auto-generated />
using System;
using AgenciaTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgenciaTurismo.Migrations
{
    [DbContext(typeof(BancoDados))]
    [Migration("20211219014111_atualizacaocliente")]
    partial class atualizacaocliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgenciaTurismo.Models.ClientDestino", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "DestinoId");

                    b.HasIndex("DestinoId");

                    b.ToTable("ClientsDestinos");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Desconto")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId")
                        .IsUnique();

                    b.ToTable("Promocaos");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.ClientDestino", b =>
                {
                    b.HasOne("AgenciaTurismo.Models.Cliente", "Cliente")
                        .WithMany("ClientsDestinos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgenciaTurismo.Models.Destino", "Destino")
                        .WithMany("ClientsDestinos")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Promocao", b =>
                {
                    b.HasOne("AgenciaTurismo.Models.Destino", "Destino")
                        .WithOne("Promocao")
                        .HasForeignKey("AgenciaTurismo.Models.Promocao", "DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Cliente", b =>
                {
                    b.Navigation("ClientsDestinos");
                });

            modelBuilder.Entity("AgenciaTurismo.Models.Destino", b =>
                {
                    b.Navigation("ClientsDestinos");

                    b.Navigation("Promocao");
                });
#pragma warning restore 612, 618
        }
    }
}
