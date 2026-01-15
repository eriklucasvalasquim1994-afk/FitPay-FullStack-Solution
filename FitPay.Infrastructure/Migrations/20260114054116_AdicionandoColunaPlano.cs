using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitPay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaPlano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoPlano",
                table: "Assinaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPlano",
                table: "Assinaturas");
        }
    }
}
