using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Promotions.gRPC.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "Description", "DiscountPercentage", "EndDate", "MaxUses", "StartDate", "TimesUsed" },
                values: new object[,]
                {
                    { 1, "Q60TY5JD", "Voluptatum minima assumenda explicabo odit voluptatem sit.", 12.585994345666021, new DateTime(2024, 9, 3, 2, 48, 54, 894, DateTimeKind.Local).AddTicks(8522), 791, new DateTime(2024, 3, 7, 8, 56, 18, 49, DateTimeKind.Local).AddTicks(1096), 28 },
                    { 2, "MYUEFMHZ", "Id odio debitis dolor eos corporis delectus recusandae iste sit.", 11.485227270370306, new DateTime(2024, 7, 2, 1, 27, 4, 659, DateTimeKind.Local).AddTicks(9843), 648, new DateTime(2024, 3, 28, 21, 49, 22, 93, DateTimeKind.Local).AddTicks(5813), 18 },
                    { 3, "ASGFOBZW", "Dolorum quia magnam quo molestiae et neque.", 31.143779386826871, new DateTime(2024, 4, 1, 20, 7, 24, 666, DateTimeKind.Local).AddTicks(509), 493, new DateTime(2023, 11, 23, 21, 22, 27, 231, DateTimeKind.Local).AddTicks(7158), 15 },
                    { 4, "QF4LHP93", "Qui blanditiis distinctio est officia quia doloremque eum.", 25.637874286452192, new DateTime(2024, 6, 27, 4, 40, 2, 724, DateTimeKind.Local).AddTicks(4784), 139, new DateTime(2024, 2, 4, 8, 50, 38, 677, DateTimeKind.Local).AddTicks(9001), 31 },
                    { 5, "X0EQZD8N", "Exercitationem ut molestias eum.", 16.303403936833398, new DateTime(2024, 10, 9, 9, 55, 17, 230, DateTimeKind.Local).AddTicks(5878), 143, new DateTime(2024, 6, 20, 11, 29, 9, 453, DateTimeKind.Local).AddTicks(5759), 16 },
                    { 6, "OTEEHMQH", "Earum ut minima et.", 30.815199815859408, new DateTime(2024, 9, 4, 20, 50, 41, 592, DateTimeKind.Local).AddTicks(8395), 515, new DateTime(2024, 3, 20, 13, 1, 59, 828, DateTimeKind.Local).AddTicks(4231), 18 },
                    { 7, "MIZZDPKZ", "Qui delectus placeat ducimus sunt suscipit consectetur voluptatibus.", 18.67677509838478, new DateTime(2025, 2, 14, 0, 15, 0, 534, DateTimeKind.Local).AddTicks(651), 433, new DateTime(2024, 8, 26, 17, 2, 3, 584, DateTimeKind.Local).AddTicks(42), 14 },
                    { 8, "VK1XAVLF", "Accusantium qui a dicta fugit aspernatur et illum commodi.", 22.877655082600004, new DateTime(2024, 8, 27, 11, 11, 5, 867, DateTimeKind.Local).AddTicks(9821), 463, new DateTime(2024, 8, 17, 23, 12, 39, 296, DateTimeKind.Local).AddTicks(2958), 22 },
                    { 9, "3D131RZH", "Odio eos quis quia sed.", 46.738922225829583, new DateTime(2024, 10, 28, 9, 18, 39, 681, DateTimeKind.Local).AddTicks(1113), 161, new DateTime(2024, 6, 25, 7, 22, 49, 871, DateTimeKind.Local).AddTicks(8059), 49 },
                    { 10, "RBUVNMTT", "Consequatur quaerat aut explicabo quidem magnam delectus vel nulla.", 5.0519861289140513, new DateTime(2025, 1, 29, 0, 46, 18, 84, DateTimeKind.Local).AddTicks(653), 843, new DateTime(2024, 9, 18, 4, 39, 49, 508, DateTimeKind.Local).AddTicks(30), 17 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
