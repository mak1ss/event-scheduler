using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "IsPromoCodeUsed", "PaymentMethod", "PurchasedTime", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, false, "PayPal", new DateTime(2023, 11, 30, 19, 24, 44, 997, DateTimeKind.Local).AddTicks(2876), 2, 350.01641132821340m, 11 },
                    { 2, false, "Bank Transfer", new DateTime(2023, 12, 4, 15, 59, 48, 28, DateTimeKind.Local).AddTicks(9938), 1, 887.018985832668760m, 2 },
                    { 3, true, "Credit Card", new DateTime(2024, 10, 20, 0, 38, 48, 121, DateTimeKind.Local).AddTicks(5607), 1, 776.449627089329040m, 18 },
                    { 4, false, "PayPal", new DateTime(2024, 1, 21, 9, 14, 43, 104, DateTimeKind.Local).AddTicks(3284), 2, 223.070593168626120m, 8 },
                    { 5, false, "PayPal", new DateTime(2024, 4, 28, 16, 31, 52, 939, DateTimeKind.Local).AddTicks(5572), 2, 164.23680028224460m, 7 },
                    { 6, false, "Credit Card", new DateTime(2024, 2, 11, 7, 47, 5, 517, DateTimeKind.Local).AddTicks(4866), 1, 984.666384460161460m, 9 },
                    { 7, true, "Credit Card", new DateTime(2024, 5, 25, 12, 3, 58, 71, DateTimeKind.Local).AddTicks(4278), 1, 419.165593006711300m, 16 },
                    { 8, false, "PayPal", new DateTime(2024, 3, 20, 4, 46, 28, 95, DateTimeKind.Local).AddTicks(492), 2, 339.136598605254500m, 17 },
                    { 9, true, "Credit Card", new DateTime(2024, 3, 14, 10, 53, 8, 924, DateTimeKind.Local).AddTicks(7709), 2, 264.322648071146120m, 13 },
                    { 10, true, "Bank Transfer", new DateTime(2024, 10, 1, 14, 0, 10, 308, DateTimeKind.Local).AddTicks(9845), 0, 213.464120171202300m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedAt", "EventId", "PurchaseId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 25, 9, 35, 4, 114, DateTimeKind.Local).AddTicks(2672), 1, 4, 5 },
                    { 2, new DateTime(2023, 11, 19, 15, 10, 21, 62, DateTimeKind.Local).AddTicks(9216), 11, 4, 15 },
                    { 3, new DateTime(2024, 9, 20, 19, 7, 43, 230, DateTimeKind.Local).AddTicks(1515), 8, 5, 8 },
                    { 4, new DateTime(2024, 3, 14, 13, 31, 21, 592, DateTimeKind.Local).AddTicks(2739), 17, 8, 5 },
                    { 5, new DateTime(2024, 7, 1, 13, 13, 2, 813, DateTimeKind.Local).AddTicks(2682), 3, 7, 1 },
                    { 6, new DateTime(2024, 1, 15, 18, 4, 53, 887, DateTimeKind.Local).AddTicks(9365), 7, 2, 13 },
                    { 7, new DateTime(2023, 11, 22, 11, 41, 48, 256, DateTimeKind.Local).AddTicks(409), 19, 6, 13 },
                    { 8, new DateTime(2024, 9, 28, 12, 6, 20, 297, DateTimeKind.Local).AddTicks(5348), 1, 1, 4 },
                    { 9, new DateTime(2024, 10, 17, 16, 53, 28, 238, DateTimeKind.Local).AddTicks(1033), 2, 2, 11 },
                    { 10, new DateTime(2024, 8, 28, 14, 27, 52, 919, DateTimeKind.Local).AddTicks(9950), 15, 3, 10 },
                    { 11, new DateTime(2024, 7, 27, 16, 51, 41, 615, DateTimeKind.Local).AddTicks(2852), 20, 9, 15 },
                    { 12, new DateTime(2023, 11, 20, 17, 2, 36, 302, DateTimeKind.Local).AddTicks(2443), 8, 9, 11 },
                    { 13, new DateTime(2024, 7, 10, 19, 13, 2, 366, DateTimeKind.Local).AddTicks(7813), 2, 8, 16 },
                    { 14, new DateTime(2024, 1, 25, 1, 39, 20, 947, DateTimeKind.Local).AddTicks(9533), 20, 7, 16 },
                    { 15, new DateTime(2024, 7, 15, 8, 36, 17, 830, DateTimeKind.Local).AddTicks(7000), 9, 4, 4 },
                    { 16, new DateTime(2024, 1, 9, 22, 23, 0, 491, DateTimeKind.Local).AddTicks(6654), 12, 4, 13 },
                    { 17, new DateTime(2024, 4, 12, 22, 59, 44, 968, DateTimeKind.Local).AddTicks(458), 1, 9, 6 },
                    { 18, new DateTime(2024, 10, 1, 7, 14, 16, 723, DateTimeKind.Local).AddTicks(1406), 12, 1, 11 },
                    { 19, new DateTime(2023, 12, 27, 21, 58, 57, 115, DateTimeKind.Local).AddTicks(2324), 11, 8, 1 },
                    { 20, new DateTime(2024, 10, 2, 2, 43, 50, 567, DateTimeKind.Local).AddTicks(6432), 16, 6, 12 },
                    { 21, new DateTime(2024, 10, 5, 16, 54, 46, 765, DateTimeKind.Local).AddTicks(9212), 2, 2, 16 },
                    { 22, new DateTime(2024, 6, 24, 21, 4, 14, 892, DateTimeKind.Local).AddTicks(4584), 2, 7, 8 },
                    { 23, new DateTime(2024, 4, 29, 21, 9, 37, 596, DateTimeKind.Local).AddTicks(6974), 18, 10, 4 },
                    { 24, new DateTime(2024, 2, 26, 18, 45, 21, 793, DateTimeKind.Local).AddTicks(8203), 18, 2, 17 },
                    { 25, new DateTime(2024, 2, 19, 3, 22, 7, 481, DateTimeKind.Local).AddTicks(9940), 1, 5, 3 },
                    { 26, new DateTime(2024, 10, 25, 6, 50, 17, 572, DateTimeKind.Local).AddTicks(8443), 19, 2, 8 },
                    { 27, new DateTime(2023, 11, 18, 2, 26, 15, 113, DateTimeKind.Local).AddTicks(1439), 6, 7, 8 },
                    { 28, new DateTime(2024, 1, 2, 4, 3, 29, 3, DateTimeKind.Local).AddTicks(5196), 9, 10, 6 },
                    { 29, new DateTime(2024, 2, 28, 16, 27, 17, 142, DateTimeKind.Local).AddTicks(4326), 11, 1, 14 },
                    { 30, new DateTime(2024, 6, 21, 8, 9, 8, 640, DateTimeKind.Local).AddTicks(4830), 15, 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
