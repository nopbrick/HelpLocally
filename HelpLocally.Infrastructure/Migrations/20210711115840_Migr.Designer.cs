﻿// <auto-generated />
using System;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HelpLocally.Infrastructure.Migrations
{
    [DbContext(typeof(HelpLocallyContext))]
    [Migration("20210711115840_Migr")]
    partial class Migr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HelpLocally.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HelpLocally.Domain.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("OfferTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OfferTypeId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("HelpLocally.Domain.OfferType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OfferTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("edffbc4f-84af-4303-bf15-ec7e56c4fc19"),
                            Description = "Voucher type of offer",
                            Name = "Voucher"
                        },
                        new
                        {
                            Id = new Guid("cd51444a-efcd-4933-9b38-473f9962394f"),
                            Description = "Standard product",
                            Name = "Product"
                        });
                });

            modelBuilder.Entity("HelpLocally.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84646cbc-096b-4d62-87b4-a5f5e550d9e1"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("bedc6651-217f-42f4-9ec5-03cdda53565a"),
                            Name = "Company"
                        },
                        new
                        {
                            Id = new Guid("8553055f-86c2-488e-afb7-80862489a211"),
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("HelpLocally.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HelpLocally.Domain.Company", b =>
                {
                    b.HasOne("HelpLocally.Domain.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelpLocally.Domain.Offer", b =>
                {
                    b.HasOne("HelpLocally.Domain.Company", null)
                        .WithMany("Offers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpLocally.Domain.OfferType", "OfferType")
                        .WithMany()
                        .HasForeignKey("OfferTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
