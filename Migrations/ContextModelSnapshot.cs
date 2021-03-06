﻿// <auto-generated />
using System;
using AspNetCore31Test2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCore31Test2.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCore31Test2.Models.Entity1", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entity1s");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36471298-e1ff-4516-b1c9-add01e95de06"),
                            Name = "My First Entity1"
                        },
                        new
                        {
                            Id = new Guid("1e3942dd-e344-4da6-a822-d5e93e265626"),
                            Name = "My Second Entity1"
                        });
                });

            modelBuilder.Entity("AspNetCore31Test2.Models.Entity2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Entity1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Entity1Id")
                        .IsUnique();

                    b.ToTable("Entity2s");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"),
                            Entity1Id = new Guid("36471298-e1ff-4516-b1c9-add01e95de06"),
                            Name = "My First Entity2"
                        },
                        new
                        {
                            Id = new Guid("6bd309a0-243f-4f24-a4f2-b6dab18bc4ff"),
                            Entity1Id = new Guid("1e3942dd-e344-4da6-a822-d5e93e265626"),
                            Name = "My Second Entity2"
                        });
                });

            modelBuilder.Entity("AspNetCore31Test2.Models.Entity3", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Entity2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Entity2Id");

                    b.ToTable("Entity3s");

                    b.HasData(
                        new
                        {
                            Id = new Guid("411241d5-4c77-4307-963b-ad316a37fccd"),
                            Entity2Id = new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"),
                            Name = "My First Entity3"
                        },
                        new
                        {
                            Id = new Guid("34c5d5f6-1bc1-4b28-85a7-5cd71cb4b5fc"),
                            Entity2Id = new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"),
                            Name = "My Second Entity3"
                        },
                        new
                        {
                            Id = new Guid("15196e1b-f4d7-4059-9681-a9f8ef632c12"),
                            Entity2Id = new Guid("6bd309a0-243f-4f24-a4f2-b6dab18bc4ff"),
                            Name = "My Third Entity3"
                        });
                });

            modelBuilder.Entity("AspNetCore31Test2.Models.Entity2", b =>
                {
                    b.HasOne("AspNetCore31Test2.Models.Entity1", "Entity1")
                        .WithOne("Entity2")
                        .HasForeignKey("AspNetCore31Test2.Models.Entity2", "Entity1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore31Test2.Models.Entity3", b =>
                {
                    b.HasOne("AspNetCore31Test2.Models.Entity2", "Entity2")
                        .WithMany("Entity3")
                        .HasForeignKey("Entity2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
