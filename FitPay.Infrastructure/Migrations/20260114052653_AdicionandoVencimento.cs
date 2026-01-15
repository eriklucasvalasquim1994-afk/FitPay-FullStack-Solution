using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitPay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoVencimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Metodo",
                table: "Assinaturas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Assinaturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProximoVencimento",
                table: "Assinaturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Assinaturas");

            migrationBuilder.DropColumn(
                name: "ProximoVencimento",
                table: "Assinaturas");

            migrationBuilder.AlterColumn<int>(
                name: "Metodo",
                table: "Assinaturas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
