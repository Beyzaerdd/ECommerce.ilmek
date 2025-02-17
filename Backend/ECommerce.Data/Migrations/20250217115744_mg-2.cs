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
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32a7ba12-0bab-45c8-a9a7-5e2cc01cc1b7", new DateTime(2025, 2, 17, 14, 57, 43, 726, DateTimeKind.Local).AddTicks(8146), "AQAAAAIAAYagAAAAEERvulnmbr1WIsLQEYw2LcmiKLb8Y4+OqOvnNZcOgV05NJcqdwgALZ2+hMIwh/zurg==", "32ffecb3-bd67-4b24-a644-c4424d65b2e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b7b85b3-b96b-47f3-9158-b7842adc3bb2", new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(499), "AQAAAAIAAYagAAAAEKLgVRCI6hu5l32jqEhFJrh3MkzMS7HFIVRqKOMvV8DcBAlsnRszwFYHlyvfKddm2g==", "3394d263-3df6-40c0-8ec0-e8315098f252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b83855c9-cdd2-4c1e-a194-b5caabde5c95", new DateTime(2025, 2, 17, 14, 57, 43, 774, DateTimeKind.Local).AddTicks(2650), "AQAAAAIAAYagAAAAENva2XSH9RuVOgP2etMQ+M4WGvZx5zf6apBufWY1H1nE5mtff39UTgiZ4qxIF0Xq8g==", "f3559646-1d68-4ba1-847b-b5d2813f3329" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 679, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 57, 43, 820, DateTimeKind.Local).AddTicks(326));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a17c9347-a6ed-4f5e-8f39-b56b3ab0efaf", new DateTime(2025, 2, 17, 14, 47, 20, 479, DateTimeKind.Local).AddTicks(4931), "AQAAAAIAAYagAAAAELkvDW2/rX0QyuG/bS7rul0UqoT+TSa3YxBTJhLn1JcFJpg3vKOnA74aCEozP2OP4w==", "d7c3b8a5-4a57-40d1-a2fa-8f2f02650c98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f500075-daf0-4237-833f-6b68f0155c50", new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(4014), "AQAAAAIAAYagAAAAEM7LCXyVIuLX80DU+f56M2K5B15OpfM1UNS+NQ5SQCP5JR0LbDjoa4C6VzS+F8+XoQ==", "081e859c-5820-4e60-aca4-d4f33b18d01e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c79deecc-5509-4619-b30a-8610af079b7e", new DateTime(2025, 2, 17, 14, 47, 20, 538, DateTimeKind.Local).AddTicks(2630), "AQAAAAIAAYagAAAAEB0SzA6QXzGQ8Dndqif/pGyfmAT+mo02i3ljnVzIOUV3hgQX6laOHZicbM9ifqdOmw==", "40ba7056-2c79-4451-af22-464decb39666" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 429, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 17, 14, 47, 20, 600, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
