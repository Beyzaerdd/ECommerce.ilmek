using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1cfad82-c0ed-4f33-ac6b-67b6e5f4b323", new DateTime(2025, 2, 7, 23, 58, 15, 560, DateTimeKind.Local).AddTicks(8555), "AQAAAAIAAYagAAAAEMjVSoUkYDeW4rAPIp3tI9mLjvuSHIEuQ33qSuEuf9iZUbNkTLYdpk5V2d/Z06Odvg==", "adc05923-1d4f-4993-8fd1-64febfdb913f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f182319-3bff-42e9-a037-f07617410232", new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4575), "AQAAAAIAAYagAAAAEL8g6+5v40m6lKpAWS5Ukwblq9CM5m9w3Fk+Jtph+YR/vOOheJI3YW1dXbEY4F0UQA==", "c95e3017-6af5-4569-80bb-504219908a9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8915228-a695-4045-b4eb-a3291a94e2e3", new DateTime(2025, 2, 7, 23, 58, 15, 594, DateTimeKind.Local).AddTicks(8642), "AQAAAAIAAYagAAAAECSSRb+sANQMQ4XE9RbsYo1B0Y7dHzozsYydiBnv0y1hsdmLsQwNuAG//r3/dzwEmQ==", "3a5135e0-df98-4d7b-b8da-e836547fb97c" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 23, 58, 15, 630, DateTimeKind.Local).AddTicks(3891));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 2, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1456), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 4, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1477), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 7, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1481), 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 6, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1484), 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 4, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1487), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 8, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1492), 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "CreatedAt", "Size" },
                values: new object[] { 4, new DateTime(2025, 2, 7, 23, 48, 37, 216, DateTimeKind.Local).AddTicks(1490), 0 });
        }
    }
}
