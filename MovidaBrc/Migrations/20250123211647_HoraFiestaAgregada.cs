using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovidaBrc.Migrations
{
    /// <inheritdoc />
    public partial class HoraFiestaAgregada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoraFiesta",
                table: "Fiestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFiesta",
                table: "Fiestas");
        }
    }
}
