using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableColors",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableSizes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "881ef1f1-1b3f-4d36-b4f2-a72947d5e2b1", new DateTime(2025, 2, 7, 23, 48, 37, 146, DateTimeKind.Local).AddTicks(8935), "AQAAAAIAAYagAAAAEL0KnnZGKXsHqNeM0+96rt8EhFB8hQ2oNcbOALTlldYw5bSPaXAWV2f7w/F6n/ZGRw==", "ea531af5-d1d7-48bd-a5b1-3645d430861d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec720ed0-46e9-40e0-8331-9e7652ed927d", new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(874), "AQAAAAIAAYagAAAAEPFzV6ph7qoiAmCp0e9XpFKy3IRTEq5m+6yFTiUWBxbQDu5m/yKNVzBIa6EFbXtE8g==", "77cfc3f8-035c-4af6-b7a3-31c63bc53f35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb7c0c5f-686d-4d95-9c4f-58c1ecfdaaaf", new DateTime(2025, 2, 7, 23, 48, 37, 181, DateTimeKind.Local).AddTicks(5469), "AQAAAAIAAYagAAAAEABlZM9f9ufdq2U6OuSq6QtxYuTVuWLKZLohFVIrhPDntbPNARXCKEsBmLqbOV2jmw==", "a25d2726-b8b4-4663-b90e-0644458212ff" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 48, 37, 112, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[1,2]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1456) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[1,2]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[1,2]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[1,2]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[0]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[0]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvailableColors", "AvailableSizes", "CreatedAt" },
                values: new object[] { "[7,11]", "[0]", new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1490) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableColors",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableSizes",
                table: "Products");

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
    }
}
