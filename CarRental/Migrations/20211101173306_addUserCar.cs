using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class addUserCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samochody",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rocznik = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodzaj_Nadwozia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodzaj_Skrzyni_Biegow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodzaj_Paliwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Moc = table.Column<int>(type: "int", nullable: false),
                    Liczba_Miejsc = table.Column<int>(type: "int", nullable: false),
                    Liczba_Drzwi = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Zdjecie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dostepny = table.Column<bool>(type: "bit", nullable: false),
                    Data_Wypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data_Oddania = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochody", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_uzytkownika = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Hasło = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numer_telefonu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samochody");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");
        }
    }
}
