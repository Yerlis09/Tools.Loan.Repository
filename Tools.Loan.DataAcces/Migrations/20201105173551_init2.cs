using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Rentada",
                table: "Herramienta",
                nullable: true);

            migrationBuilder.InsertData(
                table: "HerramientaMetaData",
                columns: new[] { "Id", "CategoriaId", "Marca", "Nombre", "Serial" },
                values: new object[] { 1, null, "Cat", "Martillo", "AFFFD234" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Herramienta",
                columns: new[] { "Id", "Descripción", "HerramientaMetaDataID", "Puesto", "Rentada" },
                values: new object[,]
                {
                    { 1, "N/A", 1, null, null },
                    { 2, "N/A", 1, null, null },
                    { 3, "N/A", 1, null, null },
                    { 4, "N/A", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Nombre", "Password", "RoleId", "UserName" },
                values: new object[] { 1, "Admin", "123", 1, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Role_RoleName",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Herramienta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Herramienta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Herramienta",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Herramienta",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HerramientaMetaData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Rentada",
                table: "Herramienta");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
