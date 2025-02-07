using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb9728fa-bafd-45ef-8f2c-a1f415a40acb", new DateTime(2025, 2, 7, 20, 19, 49, 743, DateTimeKind.Local).AddTicks(5261), "AQAAAAIAAYagAAAAEL07bxlA1XFHvF2KRfbCUd1XymcCO+KsJi5Sb1Ujw7+75385suzPxCUqD3l5BMZUSg==", "8821f1e8-cf41-4e96-b0df-a7667fd2d1d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb213665-08e3-47a0-9d55-cf286cd84d1d", new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2546), "AQAAAAIAAYagAAAAEK4nP7btkiTyj+TKndUHaJLqOTBOvV4+/CJp4U5wR6SHEtDKl/tRa67cKuz/FtpK2w==", "671f95d6-6e87-47fe-8b2b-1520f4196a16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a67a4f0-ab26-408c-b5f0-40eaf48d5994", new DateTime(2025, 2, 7, 20, 19, 49, 778, DateTimeKind.Local).AddTicks(971), "AQAAAAIAAYagAAAAEPZFAhani1N5C4JUpX3MNG+vgiAIczmxpJZ9E0ZVqmOOHTuk7YQYEqM/GJW5xkTBwg==", "e71e9ec8-ab3c-48b5-b195-1aba12b4b82a" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 709, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2448), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2454), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2457), 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2546), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 8, new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2549), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2547), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3645b64-7a54-4159-9913-15eee2453edc", new DateTime(2025, 2, 5, 22, 19, 52, 264, DateTimeKind.Local).AddTicks(4802), "AQAAAAIAAYagAAAAEAucAZ9dcGZqIUFIQOE9S0IeJPdQ8F04PcdyAdgxu2e8+64403/KWN6gx9GoX35LOA==", "e12b5625-c513-46ed-8341-2bb5fb071bcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca231131-fa04-4d8e-aeac-0995544ab3b6", new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(7035), "AQAAAAIAAYagAAAAEPVI2dvJEXagOVXkry/Iph/atwJ6sYQElgjqO6P+HfcLinuC9uqvD42WJTeMA1eBdw==", "38b281d3-796e-4926-beda-011755c3b3ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f08706d8-f5d6-4de9-be1c-6fcb605b2ac9", new DateTime(2025, 2, 5, 22, 19, 52, 346, DateTimeKind.Local).AddTicks(7500), "AQAAAAIAAYagAAAAEJKHNJ2pSInPZ/7lXvUUgYfOtYlnU7lFFFYOSEOPkUlA2NRYMrPpw0RcIoxPFeDm9g==", "97d6ed6e-e538-4d16-8182-78af91f32e12" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 199, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3518), 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3526), 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3544), 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3546), 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 11, new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3549), 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Size" },
                values: new object[] { new DateTime(2025, 2, 5, 22, 19, 52, 512, DateTimeKind.Local).AddTicks(3548), 4 });
        }
    }
}
