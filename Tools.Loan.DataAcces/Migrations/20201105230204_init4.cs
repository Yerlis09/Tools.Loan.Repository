using Microsoft.EntityFrameworkCore.Migrations;

namespace Tools.Loan.DataAcces.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Role_RoleName",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuario",
                maxLength: 22,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                maxLength: 22,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                maxLength: 22,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_UserName",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Role_RoleName",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 22);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 22);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 22);

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
    }
}
