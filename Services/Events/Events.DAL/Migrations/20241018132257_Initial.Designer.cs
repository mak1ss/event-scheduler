﻿// <auto-generated />
using System;
using Events.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Events.DAL.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20241018132257_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_ServcieManagement.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 17, 9, 54, 46, 665, DateTimeKind.Local).AddTicks(8043),
                            Description = "Nihil ut praesentium et blanditiis quasi est aut est.",
                            Name = "Outdoors",
                            UpdatedAt = new DateTime(2024, 10, 17, 17, 26, 53, 370, DateTimeKind.Local).AddTicks(8128)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 17, 10, 37, 12, 231, DateTimeKind.Local).AddTicks(6530),
                            Description = "Vel consequatur reprehenderit autem delectus voluptatem similique consequuntur ea consequatur.",
                            Name = "Beauty, Movies & Baby",
                            UpdatedAt = new DateTime(2024, 10, 18, 10, 26, 53, 695, DateTimeKind.Local).AddTicks(5905)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 18, 6, 49, 53, 300, DateTimeKind.Local).AddTicks(8827),
                            Description = "Aut architecto atque voluptate porro.",
                            Name = "Grocery",
                            UpdatedAt = new DateTime(2024, 10, 18, 6, 16, 24, 441, DateTimeKind.Local).AddTicks(6593)
                        });
                });

            modelBuilder.Entity("EF_ServcieManagement.DAL.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 17, 4, 50, 28, 545, DateTimeKind.Local).AddTicks(2215),
                            Description = "Consectetur in et delectus praesentium quam iure alias omnis doloremque.\nRerum aut maiores dolor consequuntur recusandae dolores ducimus consequuntur ipsa.\nVel non velit nostrum aut eius sapiente voluptatem commodi voluptates.",
                            Name = "Handcrafted Plastic Car",
                            Price = 831.56m,
                            UpdatedAt = new DateTime(2024, 10, 18, 10, 6, 22, 394, DateTimeKind.Local).AddTicks(879)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 10, 17, 8, 0, 13, 178, DateTimeKind.Local).AddTicks(66),
                            Description = "Eum illo totam nostrum earum nihil sit neque sint.\nAut officia labore omnis voluptas quae expedita.\nOfficiis et aut voluptatum et numquam illo corrupti ratione.",
                            Name = "Tasty Frozen Gloves",
                            Price = 488.75m,
                            UpdatedAt = new DateTime(2024, 10, 18, 6, 43, 24, 159, DateTimeKind.Local).AddTicks(9676)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 17, 12, 14, 28, 265, DateTimeKind.Local).AddTicks(4245),
                            Description = "Et sed quidem iure.\nNumquam iusto quod fuga esse enim vero sed commodi qui.\nSed quia ut voluptatem quos maiores.",
                            Name = "Licensed Granite Mouse",
                            Price = 342.91m,
                            UpdatedAt = new DateTime(2024, 10, 18, 12, 57, 8, 978, DateTimeKind.Local).AddTicks(8962)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 17, 14, 35, 54, 992, DateTimeKind.Local).AddTicks(6054),
                            Description = "Vel vero et fugit similique.\nMaxime autem tempore minima laborum minus sed aut illo ut.\nDicta ea eum recusandae est eos iste.",
                            Name = "Unbranded Concrete Shoes",
                            Price = 234.11m,
                            UpdatedAt = new DateTime(2024, 10, 18, 4, 11, 36, 921, DateTimeKind.Local).AddTicks(8353)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 10, 17, 16, 46, 37, 746, DateTimeKind.Local).AddTicks(6644),
                            Description = "Harum eveniet assumenda quia asperiores quae saepe quod ipsam eligendi.\nIusto ipsa voluptates ipsum maxime blanditiis ut.\nUt error accusantium totam tenetur maxime.",
                            Name = "Sleek Frozen Computer",
                            Price = 435.89m,
                            UpdatedAt = new DateTime(2024, 10, 18, 1, 7, 18, 33, DateTimeKind.Local).AddTicks(2838)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 17, 9, 12, 38, 456, DateTimeKind.Local).AddTicks(8449),
                            Description = "Aut voluptatem blanditiis dolores vitae sapiente ut alias.\nDicta vero consequatur alias sed dolor nam.\nDolor mollitia numquam.",
                            Name = "Practical Fresh Shirt",
                            Price = 809.50m,
                            UpdatedAt = new DateTime(2024, 10, 17, 22, 10, 30, 600, DateTimeKind.Local).AddTicks(3797)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 10, 17, 21, 26, 40, 37, DateTimeKind.Local).AddTicks(9122),
                            Description = "Non aliquam odit molestiae sunt iure.\nDistinctio soluta ex voluptatem.\nAut ut a iusto sit consectetur.",
                            Name = "Refined Granite Chicken",
                            Price = 268.89m,
                            UpdatedAt = new DateTime(2024, 10, 17, 16, 45, 48, 914, DateTimeKind.Local).AddTicks(37)
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 0,
                            CreatedAt = new DateTime(2024, 10, 17, 8, 53, 27, 513, DateTimeKind.Local).AddTicks(7401),
                            Description = "Voluptas quas quas rerum quisquam.\nAmet doloribus odio sunt.\nDistinctio ut et provident magni qui veniam nesciunt occaecati.",
                            Name = "Tasty Concrete Gloves",
                            Price = 257.21m,
                            UpdatedAt = new DateTime(2024, 10, 18, 1, 21, 3, 262, DateTimeKind.Local).AddTicks(3859)
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 10, 18, 10, 41, 22, 658, DateTimeKind.Local).AddTicks(4353),
                            Description = "Provident et est soluta velit harum cumque reiciendis blanditiis.\nNon adipisci eum nemo nihil deserunt repudiandae.\nQuasi a et porro aut ut animi sapiente nihil.",
                            Name = "Ergonomic Granite Hat",
                            Price = 167.09m,
                            UpdatedAt = new DateTime(2024, 10, 17, 23, 28, 41, 404, DateTimeKind.Local).AddTicks(7279)
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 0,
                            CreatedAt = new DateTime(2024, 10, 18, 2, 52, 33, 640, DateTimeKind.Local).AddTicks(9607),
                            Description = "Blanditiis necessitatibus voluptatem repellendus voluptate in.\nVel et quia impedit sed et est ipsam harum.\nIn ipsam quibusdam vel rem.",
                            Name = "Ergonomic Metal Chips",
                            Price = 523.07m,
                            UpdatedAt = new DateTime(2024, 10, 17, 22, 14, 3, 436, DateTimeKind.Local).AddTicks(5418)
                        });
                });

            modelBuilder.Entity("EF_ServcieManagement.DAL.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 18, 13, 9, 29, 936, DateTimeKind.Local).AddTicks(6241),
                            Name = "Awesome",
                            UpdatedAt = new DateTime(2024, 10, 18, 4, 45, 57, 268, DateTimeKind.Local).AddTicks(7106)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 18, 12, 12, 37, 835, DateTimeKind.Local).AddTicks(7416),
                            Name = "Intelligent",
                            UpdatedAt = new DateTime(2024, 10, 18, 6, 18, 40, 433, DateTimeKind.Local).AddTicks(4686)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 16, 21, 16, 45, 44, DateTimeKind.Local).AddTicks(1772),
                            Name = "Handmade",
                            UpdatedAt = new DateTime(2024, 10, 18, 0, 1, 10, 764, DateTimeKind.Local).AddTicks(8448)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 10, 17, 22, 4, 54, 492, DateTimeKind.Local).AddTicks(4601),
                            Name = "Awesome",
                            UpdatedAt = new DateTime(2024, 10, 17, 22, 34, 45, 322, DateTimeKind.Local).AddTicks(3981)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 10, 18, 10, 22, 11, 313, DateTimeKind.Local).AddTicks(6499),
                            Name = "Intelligent",
                            UpdatedAt = new DateTime(2024, 10, 18, 1, 39, 14, 880, DateTimeKind.Local).AddTicks(377)
                        });
                });

            modelBuilder.Entity("EventTag", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("eventTag", (string)null);
                });

            modelBuilder.Entity("EF_ServcieManagement.DAL.Entities.Event", b =>
                {
                    b.HasOne("EF_ServcieManagement.DAL.Entities.Category", "Category")
                        .WithMany("Event")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EventTag", b =>
                {
                    b.HasOne("EF_ServcieManagement.DAL.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_ServcieManagement.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_ServcieManagement.DAL.Entities.Category", b =>
                {
                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
