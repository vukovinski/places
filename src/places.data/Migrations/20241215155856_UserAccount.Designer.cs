﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using places.data;

#nullable disable

namespace places.data.Migrations
{
    [DbContext(typeof(PlacesDbContext))]
    [Migration("20241215155856_UserAccount")]
    partial class UserAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("places.data.Place", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<string>("LocationData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("places.data.RequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponseData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestLog");
                });

            modelBuilder.Entity("places.data.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
