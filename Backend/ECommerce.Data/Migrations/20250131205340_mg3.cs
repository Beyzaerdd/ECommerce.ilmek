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
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Orders");

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11098cd7-7d04-4a76-8f2e-299a94ea6779", new DateTime(2025, 1, 31, 22, 16, 44, 549, DateTimeKind.Local).AddTicks(7822), "AQAAAAIAAYagAAAAEL2gjc9hkjRzdqBUYSHAzMx5jP+H5aQ5QJJoD1E25SD+MaqJCkBuv/avdi6rR4Vj3Q==", "f4459108-a012-441c-aa66-38793fa60f3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4d183e4-049c-46a7-a277-e4bfd396c45d", new DateTime(2025, 1, 31, 22, 16, 44, 501, DateTimeKind.Local).AddTicks(3434), "AQAAAAIAAYagAAAAEIMOQNgGgi49kk2o8tn8ncnm83q9ThHol1IJmduD3G0UCxKPYjUOOOZlTmfBGB9vtw==", "767d14e2-2061-4942-8886-62548f3b7aee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92b03466-188d-478c-b33f-c484380a19e4", new DateTime(2025, 1, 31, 22, 16, 44, 607, DateTimeKind.Local).AddTicks(6622), "AQAAAAIAAYagAAAAEG3sT8cQ3NZsXy1NX+nP+XEqNZgzu6ki1f5JJqLx07NqHsVV9hm9pqUTbfT8ACIBDw==", "d899f9c7-05f6-4ad5-8da1-777dcc5f4bcd" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3209));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 501, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 31, 19, 16, 44, 672, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoices_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
