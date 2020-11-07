using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class init27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Cliente",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 1,
                column: "Identificacion",
                value: "154151545454");

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 6, 19, 50, 58, 581, DateTimeKind.Utc), new DateTime(2020, 11, 9, 19, 50, 58, 581, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Identificacion",
                table: "Cliente",
                column: "Identificacion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cliente_Identificacion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Cliente");

            migrationBuilder.UpdateData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaEntrada", "FechaSalida" },
                values: new object[] { new DateTime(2020, 11, 6, 0, 23, 28, 770, DateTimeKind.Utc), new DateTime(2020, 11, 9, 0, 23, 28, 770, DateTimeKind.Utc) });
        }
    }
}
