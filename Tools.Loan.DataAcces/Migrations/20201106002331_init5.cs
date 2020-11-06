using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Address", "Apellido", "Nombre" },
                values: new object[] { 1, "Solgat", "wilimardo", "Wili" });

            migrationBuilder.InsertData(
                table: "Prestamo",
                columns: new[] { "Id", "ClienteId", "Descripción", "FechaEntrada", "FechaSalida", "HerramientaId", "UsuarioId" },
                values: new object[] { 1, 1, "Presto un martillo ", new DateTime(2020, 11, 6, 0, 23, 28, 770, DateTimeKind.Utc), new DateTime(2020, 11, 9, 0, 23, 28, 770, DateTimeKind.Utc), 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prestamo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
