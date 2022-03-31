using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class pytania : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pytania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytulu = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numer_Kontaktowy = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytania", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pytania");
        }
    }
}
