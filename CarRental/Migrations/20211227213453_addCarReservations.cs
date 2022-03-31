using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class addCarReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "RezerwacjeSamochodów",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelSamochodId = table.Column<int>(type: "int", nullable: true),
                    Samochod = table.Column<int>(type: "int", nullable: false),
                    Uzytkownik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Wypozyczenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koszt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezerwacjeSamochodów", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezerwacjeSamochodów_Samochody_RelSamochodId",
                        column: x => x.RelSamochodId,
                        principalTable: "Samochody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RezerwacjeSamochodów_RelSamochodId",
                table: "RezerwacjeSamochodów",
                column: "RelSamochodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezerwacjeSamochodów");

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Wypozyczenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koszt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RelSamochodId = table.Column<int>(type: "int", nullable: true),
                    Samochod = table.Column<int>(type: "int", nullable: false),
                    Uzytkownik = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Samochody_RelSamochodId",
                        column: x => x.RelSamochodId,
                        principalTable: "Samochody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_RelSamochodId",
                table: "Rezerwacje",
                column: "RelSamochodId");
        }
    }
}
