using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "781c1ba5-00c3-44f6-9e6f-bcff27c8ded4", new DateTime(2025, 2, 11, 16, 9, 58, 443, DateTimeKind.Local).AddTicks(4886), "AQAAAAIAAYagAAAAEMsEXbnk7B622Oq3bo15vSY4cdgxj4WV3jjmab3liMI0o144uOEzGgTLEVgqr3dCDQ==", "c31c00de-7f4c-46a0-a196-37b5c31d0066" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d1d78ff-6e8e-4a97-9b1e-0673435339fe", new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(8045), "AQAAAAIAAYagAAAAELHnmjJh8VdNpwjarQbYWr82ywez2XqwjoPKJrDCCkcR1XEulkXzcOv7GNAPy6OS1w==", "8daf76df-4467-4df6-b31c-e4c4355bfb4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4dbbc1-6eaa-422f-af5d-511dadf88a08", new DateTime(2025, 2, 11, 16, 9, 58, 498, DateTimeKind.Local).AddTicks(4943), "AQAAAAIAAYagAAAAEGhjFaAv5IAz6pMwaI3sKbHN5GV1of60tVica3v11lHpOCenxlwnXfus5Tx7Ayt5FA==", "5a169723-e305-4840-9a51-1a5d02487809" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 554, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 554, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 397, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 16, 9, 58, 555, DateTimeKind.Local).AddTicks(543));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "City", "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "b1cfad82-c0ed-4f33-ac6b-67b6e5f4b323", new DateTime(2025, 2, 7, 23, 58, 15, 560, DateTimeKind.Local).AddTicks(8555), "AQAAAAIAAYagAAAAEMjVSoUkYDeW4rAPIp3tI9mLjvuSHIEuQ33qSuEuf9iZUbNkTLYdpk5V2d/Z06Odvg==", "adc05923-1d4f-4993-8fd1-64febfdb913f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "City", "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "0f182319-3bff-42e9-a037-f07617410232", new DateTime(2025, 2, 7, 23, 58, 15, 527, DateTimeKind.Local).AddTicks(4575), "AQAAAAIAAYagAAAAEL8g6+5v40m6lKpAWS5Ukwblq9CM5m9w3Fk+Jtph+YR/vOOheJI3YW1dXbEY4F0UQA==", "c95e3017-6af5-4569-80bb-504219908a9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "City", "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "d8915228-a695-4045-b4eb-a3291a94e2e3", new DateTime(2025, 2, 7, 23, 58, 15, 594, DateTimeKind.Local).AddTicks(8642), "AQAAAAIAAYagAAAAECSSRb+sANQMQ4XE9RbsYo1B0Y7dHzozsYydiBnv0y1hsdmLsQwNuAG//r3/dzwEmQ==", "3a5135e0-df98-4d7b-b8da-e836547fb97c" });

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
    }
}
