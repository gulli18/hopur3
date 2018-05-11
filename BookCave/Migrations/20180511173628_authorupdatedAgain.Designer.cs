﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180511173628_authorupdatedAgain")]
    partial class authorupdatedAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Data.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<int>("Popularity");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.BillingAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("PropertyName");

                    b.Property<string>("StreetAdress");

                    b.Property<string>("TownCity");

                    b.Property<string>("UserId");

                    b.Property<int>("ZipPostcode");

                    b.HasKey("Id");

                    b.ToTable("BillingAdresses");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorsId");

                    b.Property<string>("Format");

                    b.Property<string>("Genre");

                    b.Property<string>("Image");

                    b.Property<string>("Language");

                    b.Property<int>("PageCount");

                    b.Property<double>("Price");

                    b.Property<int>("PublicationYear");

                    b.Property<string>("Publisher");

                    b.Property<int>("Quantity");

                    b.Property<double>("Rating");

                    b.Property<string>("ShortDescription");

                    b.Property<int>("SoldCount");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardHolderName");

                    b.Property<int>("CardNumber");

                    b.Property<int>("Month");

                    b.Property<int>("SecurityNumber");

                    b.Property<string>("UserId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ShippingAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("PropertyName");

                    b.Property<string>("StreetAdress");

                    b.Property<string>("TownCity");

                    b.Property<string>("UserId");

                    b.Property<int>("ZipPostcode");

                    b.HasKey("Id");

                    b.ToTable("ShippingAdresses");
                });
#pragma warning restore 612, 618
        }
    }
}
