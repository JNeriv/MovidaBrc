using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovidaBrc.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenYGratisBoolFiesta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GratisBoolFiesta",
                table: "Fiestas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImagenFiesta",
                table: "Fiestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GratisBoolFiesta",
                table: "Fiestas");

            migrationBuilder.DropColumn(
                name: "ImagenFiesta",
                table: "Fiestas");
        }
    }
}
