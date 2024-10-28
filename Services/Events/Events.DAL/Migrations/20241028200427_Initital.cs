using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Events.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTag",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTag", x => new { x.EventId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventTag_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 22, 21, 40, 18, 260, DateTimeKind.Local).AddTicks(629), "Ducimus beatae asperiores error vel.", "Outdoors", new DateTime(2024, 10, 28, 15, 20, 24, 482, DateTimeKind.Local).AddTicks(4781) },
                    { 2, new DateTime(2024, 6, 5, 14, 19, 53, 478, DateTimeKind.Local).AddTicks(3054), "Alias et id sint tempore laudantium temporibus eaque.", "Sports", new DateTime(2024, 10, 28, 6, 1, 36, 638, DateTimeKind.Local).AddTicks(4186) },
                    { 3, new DateTime(2024, 10, 22, 4, 37, 16, 307, DateTimeKind.Local).AddTicks(7245), "Est similique rerum ut praesentium et exercitationem.", "Clothing", new DateTime(2024, 10, 28, 2, 9, 6, 58, DateTimeKind.Local).AddTicks(9783) },
                    { 4, new DateTime(2024, 8, 18, 10, 45, 6, 862, DateTimeKind.Local).AddTicks(4360), "Similique veritatis necessitatibus est qui excepturi.", "Beauty", new DateTime(2024, 10, 28, 6, 16, 13, 453, DateTimeKind.Local).AddTicks(5893) },
                    { 5, new DateTime(2024, 8, 29, 23, 9, 7, 282, DateTimeKind.Local).AddTicks(7490), "Minus vitae quaerat minus asperiores earum quod dolor ducimus consequatur.", "Clothing", new DateTime(2024, 10, 28, 18, 49, 46, 831, DateTimeKind.Local).AddTicks(4414) }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 21, 18, 27, 26, 447, DateTimeKind.Local).AddTicks(9878), "Plastic", new DateTime(2024, 10, 28, 17, 53, 58, 13, DateTimeKind.Local).AddTicks(7012) },
                    { 2, new DateTime(2024, 1, 15, 17, 53, 59, 322, DateTimeKind.Local).AddTicks(1714), "Steel", new DateTime(2024, 10, 28, 11, 56, 24, 458, DateTimeKind.Local).AddTicks(7878) },
                    { 3, new DateTime(2023, 11, 6, 7, 2, 13, 477, DateTimeKind.Local).AddTicks(7777), "Steel", new DateTime(2024, 10, 28, 11, 54, 40, 994, DateTimeKind.Local).AddTicks(4833) },
                    { 4, new DateTime(2024, 7, 16, 4, 52, 4, 762, DateTimeKind.Local).AddTicks(9630), "Rubber", new DateTime(2024, 10, 28, 19, 19, 47, 828, DateTimeKind.Local).AddTicks(5504) },
                    { 5, new DateTime(2024, 4, 1, 22, 14, 20, 645, DateTimeKind.Local).AddTicks(5496), "Steel", new DateTime(2024, 10, 28, 1, 7, 5, 483, DateTimeKind.Local).AddTicks(3231) },
                    { 6, new DateTime(2024, 9, 14, 6, 32, 0, 740, DateTimeKind.Local).AddTicks(155), "Granite", new DateTime(2024, 10, 28, 11, 51, 8, 964, DateTimeKind.Local).AddTicks(9711) },
                    { 7, new DateTime(2024, 5, 31, 2, 11, 7, 419, DateTimeKind.Local).AddTicks(6446), "Fresh", new DateTime(2024, 10, 28, 5, 8, 50, 359, DateTimeKind.Local).AddTicks(4640) },
                    { 8, new DateTime(2024, 2, 24, 12, 15, 11, 448, DateTimeKind.Local).AddTicks(701), "Rubber", new DateTime(2024, 10, 28, 10, 34, 32, 475, DateTimeKind.Local).AddTicks(4) },
                    { 9, new DateTime(2024, 1, 26, 6, 29, 55, 492, DateTimeKind.Local).AddTicks(6825), "Metal", new DateTime(2024, 10, 28, 15, 11, 29, 615, DateTimeKind.Local).AddTicks(2250) },
                    { 10, new DateTime(2024, 9, 27, 23, 7, 47, 286, DateTimeKind.Local).AddTicks(6463), "Granite", new DateTime(2024, 10, 28, 8, 25, 12, 793, DateTimeKind.Local).AddTicks(1435) }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 1, 21, 0, 1, 639, DateTimeKind.Local).AddTicks(9150), "Deleniti ut natus voluptatem maxime officia. Culpa autem eveniet. Quidem omnis nemo officiis beatae perspiciatis. Aspernatur qui ut velit vitae. Qui laudantium beatae natus ea et dicta qui sequi at. Inventore nisi laborum repellat tempora nemo.", "Fantastic Wooden Shirt", 77.165177652028120m, new DateTime(2024, 10, 28, 12, 11, 24, 334, DateTimeKind.Local).AddTicks(2752) },
                    { 2, 2, new DateTime(2024, 2, 23, 5, 0, 16, 733, DateTimeKind.Local).AddTicks(1006), "Quia odio quo ducimus. Eius et error. Sunt consequatur molestiae incidunt assumenda excepturi eos blanditiis est. Et voluptatem ipsam totam sed quia placeat dolor accusamus. Consequatur sit aut quas sit.", "Ergonomic Frozen Keyboard", 13.84499536573802790m, new DateTime(2024, 10, 28, 21, 52, 25, 893, DateTimeKind.Local).AddTicks(9340) },
                    { 3, 1, new DateTime(2024, 2, 13, 19, 54, 22, 992, DateTimeKind.Local).AddTicks(3293), "Soluta consectetur quis. Quia accusantium velit commodi quo voluptas dolorem at. Enim sit est sequi.", "Fantastic Soft Computer", 244.432273282834060m, new DateTime(2024, 10, 28, 7, 5, 57, 48, DateTimeKind.Local).AddTicks(4756) },
                    { 4, 4, new DateTime(2023, 10, 31, 20, 46, 53, 426, DateTimeKind.Local).AddTicks(401), "Placeat earum quia adipisci reiciendis. Et reiciendis quo in quae id ad accusamus. Dicta magni porro. Sint aut et nisi nulla sit saepe fugit sint voluptas. Ut numquam eligendi tempore ratione nesciunt quia facere est.", "Fantastic Concrete Tuna", 416.491583932451640m, new DateTime(2024, 10, 28, 18, 48, 29, 869, DateTimeKind.Local).AddTicks(3477) },
                    { 5, 4, new DateTime(2024, 1, 14, 7, 57, 57, 573, DateTimeKind.Local).AddTicks(1575), "Deserunt debitis distinctio sint ducimus provident. Reprehenderit cum blanditiis ut aut doloribus harum velit. Optio voluptatem atque voluptas vitae id cum velit perferendis dolor. Cumque ratione deleniti nam voluptatem voluptatem veniam placeat eius ullam. Consequatur nesciunt nemo eligendi aperiam inventore. Aut quod rerum dolor.", "Unbranded Rubber Pizza", 189.002359314745680m, new DateTime(2024, 10, 28, 2, 43, 59, 775, DateTimeKind.Local).AddTicks(7094) },
                    { 6, 1, new DateTime(2023, 12, 13, 15, 52, 6, 504, DateTimeKind.Local).AddTicks(719), "Voluptate cumque ullam sint tempore. Id sapiente omnis quibusdam cupiditate voluptates eveniet quisquam ea. Explicabo exercitationem est magnam praesentium similique corporis nihil. Aut autem dolorem odit et quod.", "Unbranded Steel Keyboard", 19.3854255745134990m, new DateTime(2024, 10, 28, 10, 3, 0, 363, DateTimeKind.Local).AddTicks(7160) },
                    { 7, 1, new DateTime(2024, 8, 8, 10, 34, 31, 514, DateTimeKind.Local).AddTicks(9617), "Sed facilis quia autem. Id ut quo voluptatem sit. Quia voluptatem ea non odit consequatur est. Dolore ipsam rerum sunt magnam est. Eos vitae non repudiandae eum porro. Explicabo sed consequuntur.", "Practical Frozen Pants", 318.735150794143710m, new DateTime(2024, 10, 28, 12, 4, 35, 373, DateTimeKind.Local).AddTicks(6508) },
                    { 8, 2, new DateTime(2024, 1, 5, 2, 38, 27, 6, DateTimeKind.Local).AddTicks(9357), "Aut similique qui. Inventore ea dolor itaque. Quas nobis non quis. Asperiores dolore dignissimos. Alias alias quia rerum et laboriosam enim.", "Licensed Rubber Bike", 56.2600190129876330m, new DateTime(2024, 10, 28, 8, 42, 16, 358, DateTimeKind.Local).AddTicks(9077) },
                    { 9, 4, new DateTime(2024, 9, 14, 10, 46, 53, 326, DateTimeKind.Local).AddTicks(1385), "Alias ea aut corporis tempora iste. Ipsam culpa repellat iste omnis. Odio corrupti quam est temporibus qui. Exercitationem molestias voluptate quisquam neque assumenda cum. Voluptatibus sed enim. Et voluptatem illo reiciendis qui alias voluptate dolores.", "Tasty Concrete Table", 132.506626928085190m, new DateTime(2024, 10, 28, 5, 47, 29, 818, DateTimeKind.Local).AddTicks(7871) },
                    { 10, 4, new DateTime(2024, 10, 27, 12, 30, 26, 187, DateTimeKind.Local).AddTicks(7086), "Itaque velit similique fugit consectetur. Sit porro voluptatibus consequatur voluptatem nobis eum dolores et. Nisi optio officia fugiat ea. Quam voluptatem ab non amet quo veritatis tempora.", "Small Soft Salad", 329.591938398961830m, new DateTime(2024, 10, 28, 13, 44, 44, 695, DateTimeKind.Local).AddTicks(1311) },
                    { 11, 1, new DateTime(2024, 1, 2, 8, 35, 36, 187, DateTimeKind.Local).AddTicks(4366), "Facere adipisci inventore totam est. Voluptas voluptas ea dolorum officiis id et debitis. Nesciunt magni aut voluptates ipsam sed voluptatem enim est sed. Aliquid natus voluptatem veniam voluptatem illo distinctio. Deserunt aliquid impedit minus voluptatibus ducimus alias inventore voluptatem iste. In tempora aperiam et ex illum et similique vero ut.", "Handmade Soft Salad", 224.806584718833730m, new DateTime(2024, 10, 28, 20, 1, 54, 648, DateTimeKind.Local).AddTicks(5241) },
                    { 12, 1, new DateTime(2024, 10, 10, 4, 14, 59, 188, DateTimeKind.Local).AddTicks(9467), "Rem corporis cupiditate mollitia minus perspiciatis provident pariatur in. Qui sed molestias voluptas assumenda. Qui in minima aut. Omnis explicabo cum quo.", "Rustic Cotton Pants", 210.568220038483290m, new DateTime(2024, 10, 28, 7, 20, 6, 833, DateTimeKind.Local).AddTicks(7838) },
                    { 13, 4, new DateTime(2024, 10, 1, 2, 25, 17, 666, DateTimeKind.Local).AddTicks(9458), "Expedita qui atque non qui fugiat labore quos. Officia dolor suscipit dolor voluptatem in enim. Nobis doloremque explicabo magnam voluptas nisi voluptatibus provident neque.", "Generic Cotton Cheese", 147.949732566630880m, new DateTime(2024, 10, 28, 3, 46, 26, 768, DateTimeKind.Local).AddTicks(7034) },
                    { 14, 1, new DateTime(2024, 1, 8, 8, 23, 58, 360, DateTimeKind.Local).AddTicks(1167), "Aut sed minima distinctio eligendi facere officia qui. Vero reiciendis qui dignissimos exercitationem culpa modi enim exercitationem sunt. Quo ea et expedita. Dolor dolore ea iste error eius vel ratione.", "Licensed Metal Chips", 366.182674817400550m, new DateTime(2024, 10, 28, 20, 13, 40, 18, DateTimeKind.Local).AddTicks(8583) },
                    { 15, 3, new DateTime(2024, 1, 24, 14, 20, 40, 856, DateTimeKind.Local).AddTicks(4986), "Est quibusdam qui. Similique illo molestiae labore sit sint nihil consequatur. Tempore sit deleniti doloribus dolor dolores inventore minus tempore.", "Rustic Frozen Salad", 293.330692536257310m, new DateTime(2024, 10, 28, 1, 1, 15, 133, DateTimeKind.Local).AddTicks(5582) },
                    { 16, 1, new DateTime(2024, 3, 1, 21, 50, 55, 716, DateTimeKind.Local).AddTicks(3059), "Ut aliquam voluptas. Nihil ut animi quidem. Reiciendis rem enim expedita optio et rerum voluptas.", "Gorgeous Soft Cheese", 345.153149724375360m, new DateTime(2024, 10, 28, 0, 18, 40, 803, DateTimeKind.Local).AddTicks(9164) },
                    { 17, 1, new DateTime(2024, 2, 23, 11, 8, 51, 649, DateTimeKind.Local).AddTicks(35), "Ut id non suscipit et qui occaecati rerum expedita neque. In ea minus dolore nam. Quo dolores consectetur neque enim minus. Illum debitis voluptatem perspiciatis dolore facere commodi sed. Ut vel incidunt occaecati. Dolorum aut at molestiae debitis ducimus nostrum necessitatibus.", "Sleek Concrete Fish", 273.702364498512590m, new DateTime(2024, 10, 28, 15, 17, 17, 627, DateTimeKind.Local).AddTicks(1554) },
                    { 18, 1, new DateTime(2023, 11, 13, 18, 18, 6, 974, DateTimeKind.Local).AddTicks(1637), "Natus ipsam optio est quia. Ut iure voluptas. Nesciunt aliquam voluptate qui fuga nisi perferendis.", "Tasty Plastic Towels", 26.6319450696159740m, new DateTime(2024, 10, 28, 10, 38, 25, 244, DateTimeKind.Local).AddTicks(8110) },
                    { 19, 4, new DateTime(2024, 3, 6, 20, 29, 20, 22, DateTimeKind.Local).AddTicks(3770), "Quasi neque illo. Laudantium quasi repellendus molestiae cumque facere exercitationem. Blanditiis ratione dolor nesciunt ut porro odio omnis. Expedita rerum reiciendis provident id sapiente dolorum et. Qui sit sed blanditiis numquam ut tempore molestiae.", "Incredible Frozen Pizza", 282.915744690603070m, new DateTime(2024, 10, 28, 10, 2, 46, 762, DateTimeKind.Local).AddTicks(5947) },
                    { 20, 1, new DateTime(2023, 11, 5, 1, 32, 54, 245, DateTimeKind.Local).AddTicks(2688), "Cumque et recusandae consequatur ut natus. Ea sit eum et omnis delectus iusto delectus magnam. Nesciunt voluptatem neque ipsam labore qui velit dolores qui repudiandae. Eum est veritatis commodi nobis voluptates. Neque mollitia dolor maxime temporibus sapiente officia fuga.", "Generic Soft Pants", 226.590707936665790m, new DateTime(2024, 10, 28, 4, 37, 56, 734, DateTimeKind.Local).AddTicks(4103) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CategoryId",
                table: "Event",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagsId",
                table: "EventTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTag");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
