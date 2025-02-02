﻿// <auto-generated />
using System;
using Events.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Events.DAL.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventTag", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("EventTag");
                });

            modelBuilder.Entity("Events.DAL.Entities.Category", b =>
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
                            CreatedAt = new DateTime(2024, 9, 22, 21, 40, 18, 260, DateTimeKind.Local).AddTicks(629),
                            Description = "Ducimus beatae asperiores error vel.",
                            Name = "Outdoors",
                            UpdatedAt = new DateTime(2024, 10, 28, 15, 20, 24, 482, DateTimeKind.Local).AddTicks(4781)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 5, 14, 19, 53, 478, DateTimeKind.Local).AddTicks(3054),
                            Description = "Alias et id sint tempore laudantium temporibus eaque.",
                            Name = "Sports",
                            UpdatedAt = new DateTime(2024, 10, 28, 6, 1, 36, 638, DateTimeKind.Local).AddTicks(4186)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 22, 4, 37, 16, 307, DateTimeKind.Local).AddTicks(7245),
                            Description = "Est similique rerum ut praesentium et exercitationem.",
                            Name = "Clothing",
                            UpdatedAt = new DateTime(2024, 10, 28, 2, 9, 6, 58, DateTimeKind.Local).AddTicks(9783)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 8, 18, 10, 45, 6, 862, DateTimeKind.Local).AddTicks(4360),
                            Description = "Similique veritatis necessitatibus est qui excepturi.",
                            Name = "Beauty",
                            UpdatedAt = new DateTime(2024, 10, 28, 6, 16, 13, 453, DateTimeKind.Local).AddTicks(5893)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 8, 29, 23, 9, 7, 282, DateTimeKind.Local).AddTicks(7490),
                            Description = "Minus vitae quaerat minus asperiores earum quod dolor ducimus consequatur.",
                            Name = "Clothing",
                            UpdatedAt = new DateTime(2024, 10, 28, 18, 49, 46, 831, DateTimeKind.Local).AddTicks(4414)
                        });
                });

            modelBuilder.Entity("Events.DAL.Entities.Event", b =>
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
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 9, 1, 21, 0, 1, 639, DateTimeKind.Local).AddTicks(9150),
                            Description = "Deleniti ut natus voluptatem maxime officia. Culpa autem eveniet. Quidem omnis nemo officiis beatae perspiciatis. Aspernatur qui ut velit vitae. Qui laudantium beatae natus ea et dicta qui sequi at. Inventore nisi laborum repellat tempora nemo.",
                            Name = "Fantastic Wooden Shirt",
                            Price = 77.165177652028120m,
                            UpdatedAt = new DateTime(2024, 10, 28, 12, 11, 24, 334, DateTimeKind.Local).AddTicks(2752)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 2, 23, 5, 0, 16, 733, DateTimeKind.Local).AddTicks(1006),
                            Description = "Quia odio quo ducimus. Eius et error. Sunt consequatur molestiae incidunt assumenda excepturi eos blanditiis est. Et voluptatem ipsam totam sed quia placeat dolor accusamus. Consequatur sit aut quas sit.",
                            Name = "Ergonomic Frozen Keyboard",
                            Price = 13.84499536573802790m,
                            UpdatedAt = new DateTime(2024, 10, 28, 21, 52, 25, 893, DateTimeKind.Local).AddTicks(9340)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 2, 13, 19, 54, 22, 992, DateTimeKind.Local).AddTicks(3293),
                            Description = "Soluta consectetur quis. Quia accusantium velit commodi quo voluptas dolorem at. Enim sit est sequi.",
                            Name = "Fantastic Soft Computer",
                            Price = 244.432273282834060m,
                            UpdatedAt = new DateTime(2024, 10, 28, 7, 5, 57, 48, DateTimeKind.Local).AddTicks(4756)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2023, 10, 31, 20, 46, 53, 426, DateTimeKind.Local).AddTicks(401),
                            Description = "Placeat earum quia adipisci reiciendis. Et reiciendis quo in quae id ad accusamus. Dicta magni porro. Sint aut et nisi nulla sit saepe fugit sint voluptas. Ut numquam eligendi tempore ratione nesciunt quia facere est.",
                            Name = "Fantastic Concrete Tuna",
                            Price = 416.491583932451640m,
                            UpdatedAt = new DateTime(2024, 10, 28, 18, 48, 29, 869, DateTimeKind.Local).AddTicks(3477)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 1, 14, 7, 57, 57, 573, DateTimeKind.Local).AddTicks(1575),
                            Description = "Deserunt debitis distinctio sint ducimus provident. Reprehenderit cum blanditiis ut aut doloribus harum velit. Optio voluptatem atque voluptas vitae id cum velit perferendis dolor. Cumque ratione deleniti nam voluptatem voluptatem veniam placeat eius ullam. Consequatur nesciunt nemo eligendi aperiam inventore. Aut quod rerum dolor.",
                            Name = "Unbranded Rubber Pizza",
                            Price = 189.002359314745680m,
                            UpdatedAt = new DateTime(2024, 10, 28, 2, 43, 59, 775, DateTimeKind.Local).AddTicks(7094)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 12, 13, 15, 52, 6, 504, DateTimeKind.Local).AddTicks(719),
                            Description = "Voluptate cumque ullam sint tempore. Id sapiente omnis quibusdam cupiditate voluptates eveniet quisquam ea. Explicabo exercitationem est magnam praesentium similique corporis nihil. Aut autem dolorem odit et quod.",
                            Name = "Unbranded Steel Keyboard",
                            Price = 19.3854255745134990m,
                            UpdatedAt = new DateTime(2024, 10, 28, 10, 3, 0, 363, DateTimeKind.Local).AddTicks(7160)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 8, 8, 10, 34, 31, 514, DateTimeKind.Local).AddTicks(9617),
                            Description = "Sed facilis quia autem. Id ut quo voluptatem sit. Quia voluptatem ea non odit consequatur est. Dolore ipsam rerum sunt magnam est. Eos vitae non repudiandae eum porro. Explicabo sed consequuntur.",
                            Name = "Practical Frozen Pants",
                            Price = 318.735150794143710m,
                            UpdatedAt = new DateTime(2024, 10, 28, 12, 4, 35, 373, DateTimeKind.Local).AddTicks(6508)
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 1, 5, 2, 38, 27, 6, DateTimeKind.Local).AddTicks(9357),
                            Description = "Aut similique qui. Inventore ea dolor itaque. Quas nobis non quis. Asperiores dolore dignissimos. Alias alias quia rerum et laboriosam enim.",
                            Name = "Licensed Rubber Bike",
                            Price = 56.2600190129876330m,
                            UpdatedAt = new DateTime(2024, 10, 28, 8, 42, 16, 358, DateTimeKind.Local).AddTicks(9077)
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 9, 14, 10, 46, 53, 326, DateTimeKind.Local).AddTicks(1385),
                            Description = "Alias ea aut corporis tempora iste. Ipsam culpa repellat iste omnis. Odio corrupti quam est temporibus qui. Exercitationem molestias voluptate quisquam neque assumenda cum. Voluptatibus sed enim. Et voluptatem illo reiciendis qui alias voluptate dolores.",
                            Name = "Tasty Concrete Table",
                            Price = 132.506626928085190m,
                            UpdatedAt = new DateTime(2024, 10, 28, 5, 47, 29, 818, DateTimeKind.Local).AddTicks(7871)
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 10, 27, 12, 30, 26, 187, DateTimeKind.Local).AddTicks(7086),
                            Description = "Itaque velit similique fugit consectetur. Sit porro voluptatibus consequatur voluptatem nobis eum dolores et. Nisi optio officia fugiat ea. Quam voluptatem ab non amet quo veritatis tempora.",
                            Name = "Small Soft Salad",
                            Price = 329.591938398961830m,
                            UpdatedAt = new DateTime(2024, 10, 28, 13, 44, 44, 695, DateTimeKind.Local).AddTicks(1311)
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 1, 2, 8, 35, 36, 187, DateTimeKind.Local).AddTicks(4366),
                            Description = "Facere adipisci inventore totam est. Voluptas voluptas ea dolorum officiis id et debitis. Nesciunt magni aut voluptates ipsam sed voluptatem enim est sed. Aliquid natus voluptatem veniam voluptatem illo distinctio. Deserunt aliquid impedit minus voluptatibus ducimus alias inventore voluptatem iste. In tempora aperiam et ex illum et similique vero ut.",
                            Name = "Handmade Soft Salad",
                            Price = 224.806584718833730m,
                            UpdatedAt = new DateTime(2024, 10, 28, 20, 1, 54, 648, DateTimeKind.Local).AddTicks(5241)
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 10, 4, 14, 59, 188, DateTimeKind.Local).AddTicks(9467),
                            Description = "Rem corporis cupiditate mollitia minus perspiciatis provident pariatur in. Qui sed molestias voluptas assumenda. Qui in minima aut. Omnis explicabo cum quo.",
                            Name = "Rustic Cotton Pants",
                            Price = 210.568220038483290m,
                            UpdatedAt = new DateTime(2024, 10, 28, 7, 20, 6, 833, DateTimeKind.Local).AddTicks(7838)
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 10, 1, 2, 25, 17, 666, DateTimeKind.Local).AddTicks(9458),
                            Description = "Expedita qui atque non qui fugiat labore quos. Officia dolor suscipit dolor voluptatem in enim. Nobis doloremque explicabo magnam voluptas nisi voluptatibus provident neque.",
                            Name = "Generic Cotton Cheese",
                            Price = 147.949732566630880m,
                            UpdatedAt = new DateTime(2024, 10, 28, 3, 46, 26, 768, DateTimeKind.Local).AddTicks(7034)
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 1, 8, 8, 23, 58, 360, DateTimeKind.Local).AddTicks(1167),
                            Description = "Aut sed minima distinctio eligendi facere officia qui. Vero reiciendis qui dignissimos exercitationem culpa modi enim exercitationem sunt. Quo ea et expedita. Dolor dolore ea iste error eius vel ratione.",
                            Name = "Licensed Metal Chips",
                            Price = 366.182674817400550m,
                            UpdatedAt = new DateTime(2024, 10, 28, 20, 13, 40, 18, DateTimeKind.Local).AddTicks(8583)
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 1, 24, 14, 20, 40, 856, DateTimeKind.Local).AddTicks(4986),
                            Description = "Est quibusdam qui. Similique illo molestiae labore sit sint nihil consequatur. Tempore sit deleniti doloribus dolor dolores inventore minus tempore.",
                            Name = "Rustic Frozen Salad",
                            Price = 293.330692536257310m,
                            UpdatedAt = new DateTime(2024, 10, 28, 1, 1, 15, 133, DateTimeKind.Local).AddTicks(5582)
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 3, 1, 21, 50, 55, 716, DateTimeKind.Local).AddTicks(3059),
                            Description = "Ut aliquam voluptas. Nihil ut animi quidem. Reiciendis rem enim expedita optio et rerum voluptas.",
                            Name = "Gorgeous Soft Cheese",
                            Price = 345.153149724375360m,
                            UpdatedAt = new DateTime(2024, 10, 28, 0, 18, 40, 803, DateTimeKind.Local).AddTicks(9164)
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 2, 23, 11, 8, 51, 649, DateTimeKind.Local).AddTicks(35),
                            Description = "Ut id non suscipit et qui occaecati rerum expedita neque. In ea minus dolore nam. Quo dolores consectetur neque enim minus. Illum debitis voluptatem perspiciatis dolore facere commodi sed. Ut vel incidunt occaecati. Dolorum aut at molestiae debitis ducimus nostrum necessitatibus.",
                            Name = "Sleek Concrete Fish",
                            Price = 273.702364498512590m,
                            UpdatedAt = new DateTime(2024, 10, 28, 15, 17, 17, 627, DateTimeKind.Local).AddTicks(1554)
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 11, 13, 18, 18, 6, 974, DateTimeKind.Local).AddTicks(1637),
                            Description = "Natus ipsam optio est quia. Ut iure voluptas. Nesciunt aliquam voluptate qui fuga nisi perferendis.",
                            Name = "Tasty Plastic Towels",
                            Price = 26.6319450696159740m,
                            UpdatedAt = new DateTime(2024, 10, 28, 10, 38, 25, 244, DateTimeKind.Local).AddTicks(8110)
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 3, 6, 20, 29, 20, 22, DateTimeKind.Local).AddTicks(3770),
                            Description = "Quasi neque illo. Laudantium quasi repellendus molestiae cumque facere exercitationem. Blanditiis ratione dolor nesciunt ut porro odio omnis. Expedita rerum reiciendis provident id sapiente dolorum et. Qui sit sed blanditiis numquam ut tempore molestiae.",
                            Name = "Incredible Frozen Pizza",
                            Price = 282.915744690603070m,
                            UpdatedAt = new DateTime(2024, 10, 28, 10, 2, 46, 762, DateTimeKind.Local).AddTicks(5947)
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 11, 5, 1, 32, 54, 245, DateTimeKind.Local).AddTicks(2688),
                            Description = "Cumque et recusandae consequatur ut natus. Ea sit eum et omnis delectus iusto delectus magnam. Nesciunt voluptatem neque ipsam labore qui velit dolores qui repudiandae. Eum est veritatis commodi nobis voluptates. Neque mollitia dolor maxime temporibus sapiente officia fuga.",
                            Name = "Generic Soft Pants",
                            Price = 226.590707936665790m,
                            UpdatedAt = new DateTime(2024, 10, 28, 4, 37, 56, 734, DateTimeKind.Local).AddTicks(4103)
                        });
                });

            modelBuilder.Entity("Events.DAL.Entities.Tag", b =>
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
                            CreatedAt = new DateTime(2024, 10, 21, 18, 27, 26, 447, DateTimeKind.Local).AddTicks(9878),
                            Name = "Plastic",
                            UpdatedAt = new DateTime(2024, 10, 28, 17, 53, 58, 13, DateTimeKind.Local).AddTicks(7012)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 15, 17, 53, 59, 322, DateTimeKind.Local).AddTicks(1714),
                            Name = "Steel",
                            UpdatedAt = new DateTime(2024, 10, 28, 11, 56, 24, 458, DateTimeKind.Local).AddTicks(7878)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 11, 6, 7, 2, 13, 477, DateTimeKind.Local).AddTicks(7777),
                            Name = "Steel",
                            UpdatedAt = new DateTime(2024, 10, 28, 11, 54, 40, 994, DateTimeKind.Local).AddTicks(4833)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 16, 4, 52, 4, 762, DateTimeKind.Local).AddTicks(9630),
                            Name = "Rubber",
                            UpdatedAt = new DateTime(2024, 10, 28, 19, 19, 47, 828, DateTimeKind.Local).AddTicks(5504)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 4, 1, 22, 14, 20, 645, DateTimeKind.Local).AddTicks(5496),
                            Name = "Steel",
                            UpdatedAt = new DateTime(2024, 10, 28, 1, 7, 5, 483, DateTimeKind.Local).AddTicks(3231)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 9, 14, 6, 32, 0, 740, DateTimeKind.Local).AddTicks(155),
                            Name = "Granite",
                            UpdatedAt = new DateTime(2024, 10, 28, 11, 51, 8, 964, DateTimeKind.Local).AddTicks(9711)
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 5, 31, 2, 11, 7, 419, DateTimeKind.Local).AddTicks(6446),
                            Name = "Fresh",
                            UpdatedAt = new DateTime(2024, 10, 28, 5, 8, 50, 359, DateTimeKind.Local).AddTicks(4640)
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 2, 24, 12, 15, 11, 448, DateTimeKind.Local).AddTicks(701),
                            Name = "Rubber",
                            UpdatedAt = new DateTime(2024, 10, 28, 10, 34, 32, 475, DateTimeKind.Local).AddTicks(4)
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 1, 26, 6, 29, 55, 492, DateTimeKind.Local).AddTicks(6825),
                            Name = "Metal",
                            UpdatedAt = new DateTime(2024, 10, 28, 15, 11, 29, 615, DateTimeKind.Local).AddTicks(2250)
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 9, 27, 23, 7, 47, 286, DateTimeKind.Local).AddTicks(6463),
                            Name = "Granite",
                            UpdatedAt = new DateTime(2024, 10, 28, 8, 25, 12, 793, DateTimeKind.Local).AddTicks(1435)
                        });
                });

            modelBuilder.Entity("EventTag", b =>
                {
                    b.HasOne("Events.DAL.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Events.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Events.DAL.Entities.Event", b =>
                {
                    b.HasOne("Events.DAL.Entities.Category", "Category")
                        .WithMany("Event")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Events.DAL.Entities.Category", b =>
                {
                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
