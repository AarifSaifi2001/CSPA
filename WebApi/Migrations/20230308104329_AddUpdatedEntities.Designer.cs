﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(CityContext))]
    [Migration("20230308104329_AddUpdatedEntities")]
    partial class AddUpdatedEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Data.BodyType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("body")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BodyTypes");
                });

            modelBuilder.Entity("WebApi.Data.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CitiesId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Cityid")
                        .HasColumnType("int");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SellRent")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carbrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("km")
                        .HasColumnType("int");

                    b.Property<int>("modelyear")
                        .HasColumnType("int");

                    b.Property<int>("owner")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("Cityid");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("PostedBy");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WebApi.Data.Cities", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WebApi.Data.FuelType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("fuel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("WebApi.Data.Photos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Carid")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isPrimary")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Carid");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("WebApi.Data.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("mobileno")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("password")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordKey")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Data.Car", b =>
                {
                    b.HasOne("WebApi.Data.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Data.Cities", "City")
                        .WithMany()
                        .HasForeignKey("Cityid");

                    b.HasOne("WebApi.Data.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Data.Photos", b =>
                {
                    b.HasOne("WebApi.Data.Car", "Car")
                        .WithMany("Photos")
                        .HasForeignKey("Carid");
                });
#pragma warning restore 612, 618
        }
    }
}
