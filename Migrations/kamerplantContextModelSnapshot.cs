﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace kamerplantModel.Migrations
{
    [DbContext(typeof(kamerplantContext))]
    partial class kamerplantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("bestelling_model.bestelling", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("adres");

                    b.Property<string>("datum");

                    b.Property<bool>("geregistreerd");

                    b.Property<int>("klantID");

                    b.Property<double>("prijs");

                    b.Property<string>("status");

                    b.HasKey("ID");

                    b.ToTable("bestelling");
                });

            modelBuilder.Entity("bestellingproduct_model.bestellingproduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bestellingID");

                    b.Property<int?>("geregistreerdeklantID");

                    b.Property<int?>("klantID");

                    b.Property<int>("productID");

                    b.Property<double>("verkoopPrijs");

                    b.HasKey("ID");

                    b.HasIndex("bestellingID");

                    b.HasIndex("geregistreerdeklantID");

                    b.HasIndex("klantID");

                    b.HasIndex("productID");

                    b.ToTable("bestellingproduct");
                });

            modelBuilder.Entity("categorie_model.categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("beschrijving");

                    b.Property<string>("foto");

                    b.Property<string>("naam");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("categorie");
                });

            modelBuilder.Entity("geregistreerdeklant_model.geregistreerdeklant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("admin");

                    b.Property<string>("email");

                    b.Property<string>("naam");

                    b.Property<string>("wachtwoord");

                    b.HasKey("ID");

                    b.ToTable("geregistreerdeklant");
                });

            modelBuilder.Entity("klant_model.klant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("naam");

                    b.HasKey("ID");

                    b.ToTable("klant");
                });

            modelBuilder.Entity("product_model.product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("beschrijving");

                    b.Property<int>("categorieID");

                    b.Property<string>("foto");

                    b.Property<string>("naam");

                    b.Property<double>("prijs");

                    b.Property<int>("voorraad");

                    b.HasKey("ID");

                    b.HasIndex("categorieID");

                    b.ToTable("product");
                });

            modelBuilder.Entity("sessie_model.sessie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("actief");

                    b.Property<int>("geregistreerdeklantID");

                    b.Property<string>("intijd");

                    b.Property<string>("uittijd");

                    b.HasKey("ID");

                    b.ToTable("sessie");
                });

            modelBuilder.Entity("verlanglijstitem_model.verlanglijstitem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("geregistreerdeklantID");

                    b.Property<int>("productID");

                    b.HasKey("ID");

                    b.HasIndex("geregistreerdeklantID");

                    b.HasIndex("productID");

                    b.ToTable("verlanglijstitem");
                });

            modelBuilder.Entity("bestellingproduct_model.bestellingproduct", b =>
                {
                    b.HasOne("bestelling_model.bestelling", "bestelling")
                        .WithMany("producten")
                        .HasForeignKey("bestellingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("geregistreerdeklant_model.geregistreerdeklant")
                        .WithMany("bestellingen")
                        .HasForeignKey("geregistreerdeklantID");

                    b.HasOne("klant_model.klant")
                        .WithMany("bestellingen")
                        .HasForeignKey("klantID");

                    b.HasOne("product_model.product", "product")
                        .WithMany("bestellingen")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("product_model.product", b =>
                {
                    b.HasOne("categorie_model.categorie")
                        .WithMany("producten")
                        .HasForeignKey("categorieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("verlanglijstitem_model.verlanglijstitem", b =>
                {
                    b.HasOne("geregistreerdeklant_model.geregistreerdeklant")
                        .WithMany("verlanglijst")
                        .HasForeignKey("geregistreerdeklantID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("product_model.product")
                        .WithMany("verlanglijst")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
