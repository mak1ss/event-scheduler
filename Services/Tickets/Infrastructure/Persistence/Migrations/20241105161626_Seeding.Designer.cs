﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    [Migration("20241105161626_Seeding")]
    partial class Seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPromoCodeUsed")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PurchasedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "PayPal",
                            PurchasedTime = new DateTime(2023, 11, 30, 19, 24, 44, 997, DateTimeKind.Local).AddTicks(2876),
                            Status = 2,
                            TotalAmount = 350.01641132821340m,
                            UserId = 11
                        },
                        new
                        {
                            Id = 2,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "Bank Transfer",
                            PurchasedTime = new DateTime(2023, 12, 4, 15, 59, 48, 28, DateTimeKind.Local).AddTicks(9938),
                            Status = 1,
                            TotalAmount = 887.018985832668760m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsPromoCodeUsed = true,
                            PaymentMethod = "Credit Card",
                            PurchasedTime = new DateTime(2024, 10, 20, 0, 38, 48, 121, DateTimeKind.Local).AddTicks(5607),
                            Status = 1,
                            TotalAmount = 776.449627089329040m,
                            UserId = 18
                        },
                        new
                        {
                            Id = 4,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "PayPal",
                            PurchasedTime = new DateTime(2024, 1, 21, 9, 14, 43, 104, DateTimeKind.Local).AddTicks(3284),
                            Status = 2,
                            TotalAmount = 223.070593168626120m,
                            UserId = 8
                        },
                        new
                        {
                            Id = 5,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "PayPal",
                            PurchasedTime = new DateTime(2024, 4, 28, 16, 31, 52, 939, DateTimeKind.Local).AddTicks(5572),
                            Status = 2,
                            TotalAmount = 164.23680028224460m,
                            UserId = 7
                        },
                        new
                        {
                            Id = 6,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "Credit Card",
                            PurchasedTime = new DateTime(2024, 2, 11, 7, 47, 5, 517, DateTimeKind.Local).AddTicks(4866),
                            Status = 1,
                            TotalAmount = 984.666384460161460m,
                            UserId = 9
                        },
                        new
                        {
                            Id = 7,
                            IsPromoCodeUsed = true,
                            PaymentMethod = "Credit Card",
                            PurchasedTime = new DateTime(2024, 5, 25, 12, 3, 58, 71, DateTimeKind.Local).AddTicks(4278),
                            Status = 1,
                            TotalAmount = 419.165593006711300m,
                            UserId = 16
                        },
                        new
                        {
                            Id = 8,
                            IsPromoCodeUsed = false,
                            PaymentMethod = "PayPal",
                            PurchasedTime = new DateTime(2024, 3, 20, 4, 46, 28, 95, DateTimeKind.Local).AddTicks(492),
                            Status = 2,
                            TotalAmount = 339.136598605254500m,
                            UserId = 17
                        },
                        new
                        {
                            Id = 9,
                            IsPromoCodeUsed = true,
                            PaymentMethod = "Credit Card",
                            PurchasedTime = new DateTime(2024, 3, 14, 10, 53, 8, 924, DateTimeKind.Local).AddTicks(7709),
                            Status = 2,
                            TotalAmount = 264.322648071146120m,
                            UserId = 13
                        },
                        new
                        {
                            Id = 10,
                            IsPromoCodeUsed = true,
                            PaymentMethod = "Bank Transfer",
                            PurchasedTime = new DateTime(2024, 10, 1, 14, 0, 10, 308, DateTimeKind.Local).AddTicks(9845),
                            Status = 0,
                            TotalAmount = 213.464120171202300m,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 11, 25, 9, 35, 4, 114, DateTimeKind.Local).AddTicks(2672),
                            EventId = 1,
                            PurchaseId = 4,
                            UserId = 5
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 11, 19, 15, 10, 21, 62, DateTimeKind.Local).AddTicks(9216),
                            EventId = 11,
                            PurchaseId = 4,
                            UserId = 15
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 9, 20, 19, 7, 43, 230, DateTimeKind.Local).AddTicks(1515),
                            EventId = 8,
                            PurchaseId = 5,
                            UserId = 8
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 3, 14, 13, 31, 21, 592, DateTimeKind.Local).AddTicks(2739),
                            EventId = 17,
                            PurchaseId = 8,
                            UserId = 5
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 1, 13, 13, 2, 813, DateTimeKind.Local).AddTicks(2682),
                            EventId = 3,
                            PurchaseId = 7,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 1, 15, 18, 4, 53, 887, DateTimeKind.Local).AddTicks(9365),
                            EventId = 7,
                            PurchaseId = 2,
                            UserId = 13
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 11, 22, 11, 41, 48, 256, DateTimeKind.Local).AddTicks(409),
                            EventId = 19,
                            PurchaseId = 6,
                            UserId = 13
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 9, 28, 12, 6, 20, 297, DateTimeKind.Local).AddTicks(5348),
                            EventId = 1,
                            PurchaseId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 10, 17, 16, 53, 28, 238, DateTimeKind.Local).AddTicks(1033),
                            EventId = 2,
                            PurchaseId = 2,
                            UserId = 11
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 8, 28, 14, 27, 52, 919, DateTimeKind.Local).AddTicks(9950),
                            EventId = 15,
                            PurchaseId = 3,
                            UserId = 10
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 7, 27, 16, 51, 41, 615, DateTimeKind.Local).AddTicks(2852),
                            EventId = 20,
                            PurchaseId = 9,
                            UserId = 15
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2023, 11, 20, 17, 2, 36, 302, DateTimeKind.Local).AddTicks(2443),
                            EventId = 8,
                            PurchaseId = 9,
                            UserId = 11
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2024, 7, 10, 19, 13, 2, 366, DateTimeKind.Local).AddTicks(7813),
                            EventId = 2,
                            PurchaseId = 8,
                            UserId = 16
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2024, 1, 25, 1, 39, 20, 947, DateTimeKind.Local).AddTicks(9533),
                            EventId = 20,
                            PurchaseId = 7,
                            UserId = 16
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2024, 7, 15, 8, 36, 17, 830, DateTimeKind.Local).AddTicks(7000),
                            EventId = 9,
                            PurchaseId = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2024, 1, 9, 22, 23, 0, 491, DateTimeKind.Local).AddTicks(6654),
                            EventId = 12,
                            PurchaseId = 4,
                            UserId = 13
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2024, 4, 12, 22, 59, 44, 968, DateTimeKind.Local).AddTicks(458),
                            EventId = 1,
                            PurchaseId = 9,
                            UserId = 6
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2024, 10, 1, 7, 14, 16, 723, DateTimeKind.Local).AddTicks(1406),
                            EventId = 12,
                            PurchaseId = 1,
                            UserId = 11
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2023, 12, 27, 21, 58, 57, 115, DateTimeKind.Local).AddTicks(2324),
                            EventId = 11,
                            PurchaseId = 8,
                            UserId = 1
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(2024, 10, 2, 2, 43, 50, 567, DateTimeKind.Local).AddTicks(6432),
                            EventId = 16,
                            PurchaseId = 6,
                            UserId = 12
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(2024, 10, 5, 16, 54, 46, 765, DateTimeKind.Local).AddTicks(9212),
                            EventId = 2,
                            PurchaseId = 2,
                            UserId = 16
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(2024, 6, 24, 21, 4, 14, 892, DateTimeKind.Local).AddTicks(4584),
                            EventId = 2,
                            PurchaseId = 7,
                            UserId = 8
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(2024, 4, 29, 21, 9, 37, 596, DateTimeKind.Local).AddTicks(6974),
                            EventId = 18,
                            PurchaseId = 10,
                            UserId = 4
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(2024, 2, 26, 18, 45, 21, 793, DateTimeKind.Local).AddTicks(8203),
                            EventId = 18,
                            PurchaseId = 2,
                            UserId = 17
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(2024, 2, 19, 3, 22, 7, 481, DateTimeKind.Local).AddTicks(9940),
                            EventId = 1,
                            PurchaseId = 5,
                            UserId = 3
                        },
                        new
                        {
                            Id = 26,
                            CreatedAt = new DateTime(2024, 10, 25, 6, 50, 17, 572, DateTimeKind.Local).AddTicks(8443),
                            EventId = 19,
                            PurchaseId = 2,
                            UserId = 8
                        },
                        new
                        {
                            Id = 27,
                            CreatedAt = new DateTime(2023, 11, 18, 2, 26, 15, 113, DateTimeKind.Local).AddTicks(1439),
                            EventId = 6,
                            PurchaseId = 7,
                            UserId = 8
                        },
                        new
                        {
                            Id = 28,
                            CreatedAt = new DateTime(2024, 1, 2, 4, 3, 29, 3, DateTimeKind.Local).AddTicks(5196),
                            EventId = 9,
                            PurchaseId = 10,
                            UserId = 6
                        },
                        new
                        {
                            Id = 29,
                            CreatedAt = new DateTime(2024, 2, 28, 16, 27, 17, 142, DateTimeKind.Local).AddTicks(4326),
                            EventId = 11,
                            PurchaseId = 1,
                            UserId = 14
                        },
                        new
                        {
                            Id = 30,
                            CreatedAt = new DateTime(2024, 6, 21, 8, 9, 8, 640, DateTimeKind.Local).AddTicks(4830),
                            EventId = 15,
                            PurchaseId = 8,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Purchase", "Purchase")
                        .WithMany("PurchasedTickets")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Domain.Entities.Purchase", b =>
                {
                    b.Navigation("PurchasedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
