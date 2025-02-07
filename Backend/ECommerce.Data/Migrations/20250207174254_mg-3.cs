using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe0dd8d-3c8c-4a00-8ecf-86eeb50b9591", new DateTime(2025, 2, 7, 20, 42, 53, 781, DateTimeKind.Local).AddTicks(6903), "AQAAAAIAAYagAAAAEMnOV1/b34aodsn/VCgqK6LWaD4aci5lz4R+tQD7E04e9+wBAzjxpdS0kgoWHRRVCw==", "ef685155-76ea-4200-9fe1-608818c20997" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f423de4-864e-406a-ad60-cc2ebe4935ef", new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3878), "AQAAAAIAAYagAAAAEBIQDGbZuIKJLBFEAFj8PpUGGq6nkIDn1zWMw5UGko6xDT+YRYUrIGQYeaatcpFJiQ==", "7daa65a9-b503-4441-9893-65009115bf59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f65cb34f-fdd4-4f92-b6ca-e48cb96b0b90", new DateTime(2025, 2, 7, 20, 42, 53, 815, DateTimeKind.Local).AddTicks(7851), "AQAAAAIAAYagAAAAEPyy6jRJO9NWt6TdIIkxRljz0ALPh9c8LcJlznLvfNcCxFtLBKFa6CuInCdatLUYwA==", "df589864-680a-4ea1-a5ee-fec9015307b0" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 748, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 42, 53, 851, DateTimeKind.Local).AddTicks(3132));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BasketItems");

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
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2454));

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
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 20, 19, 49, 811, DateTimeKind.Local).AddTicks(2547));
        }
    }
}
