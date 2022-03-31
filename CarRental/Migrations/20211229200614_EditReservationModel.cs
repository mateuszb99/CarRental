using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class EditReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nazwa",
                table: "RezerwacjeSamochodów",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zdjecie",
                table: "RezerwacjeSamochodów",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nazwa",
                table: "RezerwacjeSamochodów");

            migrationBuilder.DropColumn(
                name: "Zdjecie",
                table: "RezerwacjeSamochodów");
        }
    }
}
