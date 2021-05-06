﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tefter;

namespace Tefter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210506122906_ChangedTables")]
    partial class ChangedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tefter.DbEntities.Car", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bulstat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Egn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FirstRegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstRegisterDateInBg")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("Kilometers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingVolumeCubicCm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Tefter.DbEntities.CarExtras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Abs")
                        .HasColumnType("bit");

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("Alarm")
                        .HasColumnType("bit");

                    b.Property<bool>("Amplifier")
                        .HasColumnType("bit");

                    b.Property<bool>("Arb")
                        .HasColumnType("bit");

                    b.Property<bool>("Asd")
                        .HasColumnType("bit");

                    b.Property<bool>("Automatic")
                        .HasColumnType("bit");

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CdChanger")
                        .HasColumnType("bit");

                    b.Property<bool>("CentralLocking")
                        .HasColumnType("bit");

                    b.Property<bool>("Climatronic")
                        .HasColumnType("bit");

                    b.Property<bool>("Ebs")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectronicGlass")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectronicMirrors")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectronicPacket")
                        .HasColumnType("bit");

                    b.Property<bool>("Esp")
                        .HasColumnType("bit");

                    b.Property<bool>("FourByFour")
                        .HasColumnType("bit");

                    b.Property<bool>("Hatch")
                        .HasColumnType("bit");

                    b.Property<bool>("Immobilizer")
                        .HasColumnType("bit");

                    b.Property<string>("Other")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SteeringWheelHydraulics")
                        .HasColumnType("bit");

                    b.Property<bool>("Stereo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("CarExtras");
                });

            modelBuilder.Entity("Tefter.DbEntities.Note", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Tefter.DbEntities.OilAndFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("OilAndFilters");
                });

            modelBuilder.Entity("Tefter.DbEntities.OtherService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("OtherServices");
                });

            modelBuilder.Entity("Tefter.DbEntities.CarExtras", b =>
                {
                    b.HasOne("Tefter.DbEntities.Car", "Car")
                        .WithOne("CarExtras")
                        .HasForeignKey("Tefter.DbEntities.CarExtras", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tefter.DbEntities.OilAndFilter", b =>
                {
                    b.HasOne("Tefter.DbEntities.Car", "Car")
                        .WithMany("OilAndFilters")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tefter.DbEntities.OtherService", b =>
                {
                    b.HasOne("Tefter.DbEntities.Car", "Car")
                        .WithMany("OtherServices")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
