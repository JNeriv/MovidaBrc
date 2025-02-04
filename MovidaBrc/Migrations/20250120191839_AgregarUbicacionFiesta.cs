﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovidaBrc.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUbicacionFiesta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacionFiesta",
                table: "Fiestas");

            migrationBuilder.AddColumn<string>(
                name: "UbicacionFiesta",
                table: "Fiestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UbicacionFiesta",
                table: "Fiestas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacionFiesta",
                table: "Fiestas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
