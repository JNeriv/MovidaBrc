using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovidaBrc.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiestas",
                columns: table => new
                {
                    IdFiesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFiesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionFiesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacionFiesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRealizacionFiesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoFiesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiestas", x => x.IdFiesta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fiestas");
        }
    }
}
