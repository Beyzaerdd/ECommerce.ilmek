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
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e9f6bc7-b7db-4d1e-ae3b-3da6d680cbad", new DateTime(2025, 1, 27, 21, 15, 15, 86, DateTimeKind.Local).AddTicks(6421), "AQAAAAIAAYagAAAAEBSXf2wWK+8Sgh6SVjeiReGH81+DcH4E/dp4z64VlUb2y3KjLkndLpRR8TXDKYHK6w==", "db680f0d-dcf0-4545-92f3-bdbc1efbed4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eaa0315-6299-485c-821a-272f59f86f8d", new DateTime(2025, 1, 27, 21, 15, 15, 40, DateTimeKind.Local).AddTicks(3728), "AQAAAAIAAYagAAAAEKy9A+w0XiVb4NzzJ5a/VJaVzqPXcM7ydeVz1D8RaiF0xZ258XempFiLuaN1O5kIpw==", "81537fe3-8cca-40ca-9c84-b0db05924f1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fd0cb3a-53cd-4e4e-af93-89d3649e4432", new DateTime(2025, 1, 27, 21, 15, 15, 132, DateTimeKind.Local).AddTicks(6686), "AQAAAAIAAYagAAAAENPlTBAbf89oZ2oMKn3pwd1VYGTiUTYuSmI5frmZ2y6Iw3p8tGk2YdaWPShAEP7dGw==", "8dccd148-9cad-4cab-937e-22045f5f7749" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 40, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 27, 18, 15, 15, 180, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "IsActive", "IsApproved" },
                values: new object[] { true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115c7796-cfac-44de-91b5-916eaae125b5",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161b",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811f466c-9d06-43f8-a054-24aedbb4161c",
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17d3129d-a0cf-4a13-87e6-0b6e533c320a", new DateTime(2025, 1, 25, 21, 23, 28, 290, DateTimeKind.Local).AddTicks(5206), "AQAAAAIAAYagAAAAEFc8S/Y3y+WPQsOH1UHji77MDhu1p9mOR/3veCML2mDFlhNusVW4xXDWeG5OeDEprQ==", "c67cb8a0-b9e3-4a8f-8e5e-958fb383c279" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cae01fd8-8cf3-4de1-93d5-2f97182fddd8", new DateTime(2025, 1, 25, 21, 23, 28, 218, DateTimeKind.Local).AddTicks(7558), "AQAAAAIAAYagAAAAEMt6mNMvq5vIedGKhtUzffUcpmvPOmqYRgpqzBneoW/+1jF6g8Ql3tU2c1X33SV38g==", "b0eb6f60-aebe-4b0e-ab1a-b6693e1d56a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5f24fa7-c2d5-421d-8fe7-eed34209803f", new DateTime(2025, 1, 25, 21, 23, 28, 335, DateTimeKind.Local).AddTicks(5710), "AQAAAAIAAYagAAAAEPeTCEU1r1KFb+433/zBqTPq7WxOHFtXXLBXmD3rkKryqz2eu4emA3Y/G2Lp1kKAMg==", "3f4165a2-17bd-4b0d-ae12-29ef0b397266" });

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 218, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(96));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 25, 18, 23, 28, 381, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                column: "IsActive",
                value: false);
        }
    }
}
