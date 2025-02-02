using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50f82ad8-7c1f-4911-840b-91c4adc0f4f9", new DateTime(2025, 2, 2, 18, 33, 25, 65, DateTimeKind.Local).AddTicks(1159), "AQAAAAIAAYagAAAAEKOw5GiTfjYlNZw0KviKOVFCA4ayAO5sti6eLzM/65116pfxmpVRk9cezZW+fN8AJQ==", "f7fdbe1f-5dd0-4263-be7f-049ef9cc8062" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "301acbf2-133c-4d2a-9771-1e47152751e0", new DateTime(2025, 2, 2, 18, 33, 25, 30, DateTimeKind.Local).AddTicks(4514), "AQAAAAIAAYagAAAAEPyvUWjEX5LTCZDZZ9fy9wyb2Cn9OW3LwTQWfebcooJsHFhERSwV3Dhavgrj/8WL6w==", "c49a7065-f801-46c1-9bbe-85a02f71ff13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "072e4d14-6846-4c85-b86a-58bb7da4b5a1", new DateTime(2025, 2, 2, 18, 33, 25, 99, DateTimeKind.Local).AddTicks(5272), "AQAAAAIAAYagAAAAEJg+/rjjzYqnoeCmEh3+tOBRqp87lhaMCNz3lwqM/85EIMXOGFT7pPn4llzRnq2woQ==", "b3202937-cef8-4184-99c1-bfc76799ad93" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 30, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 2, 15, 33, 25, 133, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                column: "IdentityNumber",
                value: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Sellers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4700e056-3ef4-4f56-82e7-d760cd366f70", new DateTime(2025, 1, 31, 23, 53, 39, 272, DateTimeKind.Local).AddTicks(9064), "AQAAAAIAAYagAAAAEIncnJekb4qAg/8GbPby35djXlKiH3358eaImIq6yKlDWvytMGWRGLlmVVpt/YzV4w==", "a9948652-3477-45df-80ab-45eff8a37b90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0e02676-ba82-406a-96df-493bf73c8cd9", new DateTime(2025, 1, 31, 23, 53, 39, 217, DateTimeKind.Local).AddTicks(6942), "AQAAAAIAAYagAAAAEGnyr10zgdfk5BMql30I++vLyN1eF/yZ1K7GXNFRTS9qtVIkk5HbCbQux0AoN8q8Gw==", "3fd185f4-8629-40c6-9f8e-e6fcaa81fdb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18c8c2d4-32e5-44b2-84b5-61dcf725ccde", new DateTime(2025, 1, 31, 23, 53, 39, 321, DateTimeKind.Local).AddTicks(5743), "AQAAAAIAAYagAAAAECL+OAMh7iYWBJPnMU6EcVGG/kR5qafIrs8dS+bB2DJMXI1OhzMu5eC/FS2HoFZcIA==", "f69cc5f0-0118-4a0b-94c0-68a9594b7dfb" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 217, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 20, 53, 39, 375, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                column: "IdentityNumber",
                value: 1);
        }
    }
}
