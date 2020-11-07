using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class init55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HerramientaDevultaFecha",
                table: "Prestamo",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 7, 0, 4, 54, 781, DateTimeKind.Utc), new DateTime(2020, 11, 10, 0, 4, 54, 781, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HerramientaDevultaFecha",
                table: "Prestamo");

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 6, 19, 50, 58, 581, DateTimeKind.Utc), new DateTime(2020, 11, 9, 19, 50, 58, 581, DateTimeKind.Utc) });
        }
    }
}
