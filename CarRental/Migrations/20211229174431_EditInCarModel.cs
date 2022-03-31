using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class EditInCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Oddania",
                table: "Samochody");

            migrationBuilder.DropColumn(
                name: "Data_Wypozyczenia",
                table: "Samochody");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Wypozyczenia",
                table: "RezerwacjeSamochodów",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Oddania",
                table: "Samochody",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Wypozyczenia",
                table: "Samochody",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Data_Wypozyczenia",
                table: "RezerwacjeSamochodów",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
