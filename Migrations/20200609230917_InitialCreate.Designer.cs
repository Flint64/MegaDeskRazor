﻿// <auto-generated />
using System;
using MegaDeskRazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskRazor.Migrations
{
    [DbContext(typeof(MegaDeskRazorContext))]
    [Migration("20200609230917_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskRazor.Models.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumDrawersId")
                        .HasColumnType("int");

                    b.Property<decimal>("SurfaceArea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SurfaceMaterialId")
                        .HasColumnType("int");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeskId");

                    b.HasIndex("NumDrawersId");

                    b.HasIndex("SurfaceMaterialId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RushOptionId")
                        .HasColumnType("int");

                    b.HasKey("DeskQuoteId");

                    b.HasIndex("DeskId");

                    b.HasIndex("RushOptionId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.NumDrawers", b =>
                {
                    b.Property<int>("NumDrawersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumberOfDrawers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NumDrawersId");

                    b.ToTable("NumDrawers");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.RushOption", b =>
                {
                    b.Property<int>("RushOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PriceBetween1000And2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceOver2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceUnder1000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RushOptionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RushOptionId");

                    b.ToTable("RushOption");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.SurfaceMaterial", b =>
                {
                    b.Property<int>("SurfaceMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SurfaceMaterialName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurfaceMaterialId");

                    b.ToTable("SurfaceMaterial");
                });

            modelBuilder.Entity("MegaDeskRazor.Models.Desk", b =>
                {
                    b.HasOne("MegaDeskRazor.Models.NumDrawers", "NumberOfDrawers")
                        .WithMany()
                        .HasForeignKey("NumDrawersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskRazor.Models.SurfaceMaterial", "SurfaceMaterial")
                        .WithMany()
                        .HasForeignKey("SurfaceMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MegaDeskRazor.Models.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskRazor.Models.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskRazor.Models.RushOption", "RushOption")
                        .WithMany()
                        .HasForeignKey("RushOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
