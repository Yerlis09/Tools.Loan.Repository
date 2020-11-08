using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class CambiosAndres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Cliente",
                newName: "Cargo");

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 7, 17, 51, 41, 412, DateTimeKind.Utc), new DateTime(2020, 11, 10, 17, 51, 41, 412, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Cliente",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 7, 0, 4, 54, 781, DateTimeKind.Utc), new DateTime(2020, 11, 10, 0, 4, 54, 781, DateTimeKind.Utc) });
        }
    }
}
