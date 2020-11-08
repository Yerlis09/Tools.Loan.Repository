using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class nuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 7, 22, 40, 55, 915, DateTimeKind.Utc), new DateTime(2020, 11, 10, 22, 40, 55, 915, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 7, 21, 31, 28, 490, DateTimeKind.Utc), new DateTime(2020, 11, 10, 21, 31, 28, 490, DateTimeKind.Utc) });
        }
    }
}
