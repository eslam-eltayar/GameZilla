﻿// <auto-generated />
using GameZilla.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameZilla.DataAccess.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameZilla.Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Film"
                        });
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "bi bi-playstation",
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "bi bi-xbox",
                            Name = "xbox"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "bi bi-nintendo-switch",
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "bi bi-pc-display",
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.GameDevice", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("GameDevices");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Game", b =>
                {
                    b.HasOne("GameZilla.Entities.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.GameDevice", b =>
                {
                    b.HasOne("GameZilla.Entities.Models.Device", "Device")
                        .WithMany("GameDevices")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameZilla.Entities.Models.Game", "Game")
                        .WithMany("GameDevices")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Device", b =>
                {
                    b.Navigation("GameDevices");
                });

            modelBuilder.Entity("GameZilla.Entities.Models.Game", b =>
                {
                    b.Navigation("GameDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
