﻿// <auto-generated />
using lab27_brian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace lab27_brian.Migrations
{
    [DbContext(typeof(lab27_brianContext))]
    partial class lab27_brianContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab27_brian.Models.LocationPost", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Contact");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Review");

                    b.HasKey("LocationID");

                    b.ToTable("LocationPost");
                });
#pragma warning restore 612, 618
        }
    }
}
