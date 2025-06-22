using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteHotelManagerment.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastLoginIP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 10,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 10,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 43, 52, 448, DateTimeKind.Local).AddTicks(9424));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastLoginIP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "DatPhongs",
                keyColumn: "Id",
                keyValue: 10,
                column: "NgayDat",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 3,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 4,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 5,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 6,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 7,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 8,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 9,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "LienHes",
                keyColumn: "Id",
                keyValue: 10,
                column: "NgayGui",
                value: new DateTime(2025, 6, 23, 0, 40, 3, 423, DateTimeKind.Local).AddTicks(1363));
        }
    }
}
