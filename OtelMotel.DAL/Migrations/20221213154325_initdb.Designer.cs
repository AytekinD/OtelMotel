﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtelMotel.DAL.Contexts;

#nullable disable

namespace OtelMotel.DAL.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20221213154325_initdb")]
    partial class initdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Kullanici", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Musteri", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CepNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriTcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Oda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<byte>("KisiSayisi")
                        .HasColumnType("tinyint");

                    b.Property<string>("OdaNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Odalar");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.OdaFiyat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("Baslangic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Bitis")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Fiyat")
                        .HasColumnType("real");

                    b.Property<Guid>("OdaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OdaId");

                    b.ToTable("OdaFiyatlari");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Rezervasyon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("CikisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GirisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MusteriId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OdaFiyatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OdaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MusteriId");

                    b.HasIndex("OdaFiyatId");

                    b.HasIndex("OdaId");

                    b.ToTable("Rezervasyonlar");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.RezervasyonDetay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MusteriId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RezervasyonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MusteriId");

                    b.HasIndex("RezervasyonId");

                    b.ToTable("RezervasyonDetaylari");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.OdaFiyat", b =>
                {
                    b.HasOne("OtelMotel.Entities.Entities.Concrete.Oda", "Oda")
                        .WithMany("OdaFiyatlari")
                        .HasForeignKey("OdaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oda");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Rezervasyon", b =>
                {
                    b.HasOne("OtelMotel.Entities.Entities.Concrete.Musteri", null)
                        .WithMany("Rezervasyonlari")
                        .HasForeignKey("MusteriId");

                    b.HasOne("OtelMotel.Entities.Entities.Concrete.OdaFiyat", "OdaFiyat")
                        .WithMany("Rezervasyonlari")
                        .HasForeignKey("OdaFiyatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OtelMotel.Entities.Entities.Concrete.Oda", "Oda")
                        .WithMany("Rezervasyonlari")
                        .HasForeignKey("OdaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Oda");

                    b.Navigation("OdaFiyat");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.RezervasyonDetay", b =>
                {
                    b.HasOne("OtelMotel.Entities.Entities.Concrete.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtelMotel.Entities.Entities.Concrete.Rezervasyon", "Rezervasyon")
                        .WithMany("RezervasyonDetaylari")
                        .HasForeignKey("RezervasyonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Musteri");

                    b.Navigation("Rezervasyon");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Musteri", b =>
                {
                    b.Navigation("Rezervasyonlari");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Oda", b =>
                {
                    b.Navigation("OdaFiyatlari");

                    b.Navigation("Rezervasyonlari");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.OdaFiyat", b =>
                {
                    b.Navigation("Rezervasyonlari");
                });

            modelBuilder.Entity("OtelMotel.Entities.Entities.Concrete.Rezervasyon", b =>
                {
                    b.Navigation("RezervasyonDetaylari");
                });
#pragma warning restore 612, 618
        }
    }
}
