using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Events.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "eventTag",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventTag", x => new { x.EventId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_eventTag_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventTag_Tag_TagsId",
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
                    { 1, new DateTime(2024, 10, 17, 9, 54, 46, 665, DateTimeKind.Local).AddTicks(8043), "Nihil ut praesentium et blanditiis quasi est aut est.", "Outdoors", new DateTime(2024, 10, 17, 17, 26, 53, 370, DateTimeKind.Local).AddTicks(8128) },
                    { 2, new DateTime(2024, 10, 17, 10, 37, 12, 231, DateTimeKind.Local).AddTicks(6530), "Vel consequatur reprehenderit autem delectus voluptatem similique consequuntur ea consequatur.", "Beauty, Movies & Baby", new DateTime(2024, 10, 18, 10, 26, 53, 695, DateTimeKind.Local).AddTicks(5905) },
                    { 3, new DateTime(2024, 10, 18, 6, 49, 53, 300, DateTimeKind.Local).AddTicks(8827), "Aut architecto atque voluptate porro.", "Grocery", new DateTime(2024, 10, 18, 6, 16, 24, 441, DateTimeKind.Local).AddTicks(6593) }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 8, 0, new DateTime(2024, 10, 17, 8, 53, 27, 513, DateTimeKind.Local).AddTicks(7401), "Voluptas quas quas rerum quisquam.\nAmet doloribus odio sunt.\nDistinctio ut et provident magni qui veniam nesciunt occaecati.", "Tasty Concrete Gloves", 257.21m, new DateTime(2024, 10, 18, 1, 21, 3, 262, DateTimeKind.Local).AddTicks(3859) },
                    { 10, 0, new DateTime(2024, 10, 18, 2, 52, 33, 640, DateTimeKind.Local).AddTicks(9607), "Blanditiis necessitatibus voluptatem repellendus voluptate in.\nVel et quia impedit sed et est ipsam harum.\nIn ipsam quibusdam vel rem.", "Ergonomic Metal Chips", 523.07m, new DateTime(2024, 10, 17, 22, 14, 3, 436, DateTimeKind.Local).AddTicks(5418) }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 13, 9, 29, 936, DateTimeKind.Local).AddTicks(6241), "Awesome", new DateTime(2024, 10, 18, 4, 45, 57, 268, DateTimeKind.Local).AddTicks(7106) },
                    { 2, new DateTime(2024, 10, 18, 12, 12, 37, 835, DateTimeKind.Local).AddTicks(7416), "Intelligent", new DateTime(2024, 10, 18, 6, 18, 40, 433, DateTimeKind.Local).AddTicks(4686) },
                    { 3, new DateTime(2024, 10, 16, 21, 16, 45, 44, DateTimeKind.Local).AddTicks(1772), "Handmade", new DateTime(2024, 10, 18, 0, 1, 10, 764, DateTimeKind.Local).AddTicks(8448) },
                    { 4, new DateTime(2024, 10, 17, 22, 4, 54, 492, DateTimeKind.Local).AddTicks(4601), "Awesome", new DateTime(2024, 10, 17, 22, 34, 45, 322, DateTimeKind.Local).AddTicks(3981) },
                    { 5, new DateTime(2024, 10, 18, 10, 22, 11, 313, DateTimeKind.Local).AddTicks(6499), "Intelligent", new DateTime(2024, 10, 18, 1, 39, 14, 880, DateTimeKind.Local).AddTicks(377) }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 10, 17, 4, 50, 28, 545, DateTimeKind.Local).AddTicks(2215), "Consectetur in et delectus praesentium quam iure alias omnis doloremque.\nRerum aut maiores dolor consequuntur recusandae dolores ducimus consequuntur ipsa.\nVel non velit nostrum aut eius sapiente voluptatem commodi voluptates.", "Handcrafted Plastic Car", 831.56m, new DateTime(2024, 10, 18, 10, 6, 22, 394, DateTimeKind.Local).AddTicks(879) },
                    { 2, 2, new DateTime(2024, 10, 17, 8, 0, 13, 178, DateTimeKind.Local).AddTicks(66), "Eum illo totam nostrum earum nihil sit neque sint.\nAut officia labore omnis voluptas quae expedita.\nOfficiis et aut voluptatum et numquam illo corrupti ratione.", "Tasty Frozen Gloves", 488.75m, new DateTime(2024, 10, 18, 6, 43, 24, 159, DateTimeKind.Local).AddTicks(9676) },
                    { 3, 1, new DateTime(2024, 10, 17, 12, 14, 28, 265, DateTimeKind.Local).AddTicks(4245), "Et sed quidem iure.\nNumquam iusto quod fuga esse enim vero sed commodi qui.\nSed quia ut voluptatem quos maiores.", "Licensed Granite Mouse", 342.91m, new DateTime(2024, 10, 18, 12, 57, 8, 978, DateTimeKind.Local).AddTicks(8962) },
                    { 4, 3, new DateTime(2024, 10, 17, 14, 35, 54, 992, DateTimeKind.Local).AddTicks(6054), "Vel vero et fugit similique.\nMaxime autem tempore minima laborum minus sed aut illo ut.\nDicta ea eum recusandae est eos iste.", "Unbranded Concrete Shoes", 234.11m, new DateTime(2024, 10, 18, 4, 11, 36, 921, DateTimeKind.Local).AddTicks(8353) },
                    { 5, 2, new DateTime(2024, 10, 17, 16, 46, 37, 746, DateTimeKind.Local).AddTicks(6644), "Harum eveniet assumenda quia asperiores quae saepe quod ipsam eligendi.\nIusto ipsa voluptates ipsum maxime blanditiis ut.\nUt error accusantium totam tenetur maxime.", "Sleek Frozen Computer", 435.89m, new DateTime(2024, 10, 18, 1, 7, 18, 33, DateTimeKind.Local).AddTicks(2838) },
                    { 6, 1, new DateTime(2024, 10, 17, 9, 12, 38, 456, DateTimeKind.Local).AddTicks(8449), "Aut voluptatem blanditiis dolores vitae sapiente ut alias.\nDicta vero consequatur alias sed dolor nam.\nDolor mollitia numquam.", "Practical Fresh Shirt", 809.50m, new DateTime(2024, 10, 17, 22, 10, 30, 600, DateTimeKind.Local).AddTicks(3797) },
                    { 7, 2, new DateTime(2024, 10, 17, 21, 26, 40, 37, DateTimeKind.Local).AddTicks(9122), "Non aliquam odit molestiae sunt iure.\nDistinctio soluta ex voluptatem.\nAut ut a iusto sit consectetur.", "Refined Granite Chicken", 268.89m, new DateTime(2024, 10, 17, 16, 45, 48, 914, DateTimeKind.Local).AddTicks(37) },
                    { 9, 2, new DateTime(2024, 10, 18, 10, 41, 22, 658, DateTimeKind.Local).AddTicks(4353), "Provident et est soluta velit harum cumque reiciendis blanditiis.\nNon adipisci eum nemo nihil deserunt repudiandae.\nQuasi a et porro aut ut animi sapiente nihil.", "Ergonomic Granite Hat", 167.09m, new DateTime(2024, 10, 17, 23, 28, 41, 404, DateTimeKind.Local).AddTicks(7279) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CategoryId",
                table: "Event",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_eventTag_TagsId",
                table: "eventTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventTag");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
