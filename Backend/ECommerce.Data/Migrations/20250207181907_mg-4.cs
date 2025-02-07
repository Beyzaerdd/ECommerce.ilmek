using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6aeefff1-3db0-4546-bf0b-7ae42d1b051e", new DateTime(2025, 2, 7, 21, 19, 7, 359, DateTimeKind.Local).AddTicks(847), "AQAAAAIAAYagAAAAEAkWIasPXcTNubpshcCHHHpPT5EDXy3XI8jACivL5vwcGi+3O51kZAyI8G9+v3hNkA==", "72292035-4688-4889-a99d-72d714c228d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fe3753f-99a5-4cbd-b75a-fd0a826969d4", new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9899), "AQAAAAIAAYagAAAAEIm47zYKInaiNWNwoQ72PlLNeNxKSTGDjURBv3o4GFqple4lyxhomYt4krymeMUIdA==", "2d575cc9-7af4-4879-a264-cbdb416e82cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20168b58-0856-4be1-b726-4d2a5a5c1aaf", new DateTime(2025, 2, 7, 21, 19, 7, 393, DateTimeKind.Local).AddTicks(1117), "AQAAAAIAAYagAAAAEL0wTsKHlpbWmsqr8AMeh9Wg/W8tEKrnRSp5cty+oDHIFjSTfGi21N4oAj8sjhFMjA==", "e52a60ae-c87d-4eb8-8862-c70931620d13" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 324, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 19, 7, 427, DateTimeKind.Local).AddTicks(4705));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
