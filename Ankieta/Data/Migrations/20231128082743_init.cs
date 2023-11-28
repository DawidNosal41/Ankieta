using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ankieta.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ankieta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ankieta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odpowiedz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdpowiedzUzytkownika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    OdpowiedzId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdpowiedzUzytkownika", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdpowiedzUzytkownika_Odpowiedz_OdpowiedzId",
                        column: x => x.OdpowiedzId,
                        principalTable: "Odpowiedz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdpowiedzUzytkownika_Uzytkownik_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pytanie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypPytania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdpowiedzUzytkownikaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pytanie_OdpowiedzUzytkownika_OdpowiedzUzytkownikaId",
                        column: x => x.OdpowiedzUzytkownikaId,
                        principalTable: "OdpowiedzUzytkownika",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PytanieAnkieta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PytanieId = table.Column<int>(type: "int", nullable: false),
                    AnkietaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PytanieAnkieta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PytanieAnkieta_Ankieta_AnkietaId",
                        column: x => x.AnkietaId,
                        principalTable: "Ankieta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PytanieAnkieta_Pytanie_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedzUzytkownika_OdpowiedzId",
                table: "OdpowiedzUzytkownika",
                column: "OdpowiedzId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedzUzytkownika_UzytkownikId",
                table: "OdpowiedzUzytkownika",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pytanie_OdpowiedzUzytkownikaId",
                table: "Pytanie",
                column: "OdpowiedzUzytkownikaId");

            migrationBuilder.CreateIndex(
                name: "IX_PytanieAnkieta_AnkietaId",
                table: "PytanieAnkieta",
                column: "AnkietaId");

            migrationBuilder.CreateIndex(
                name: "IX_PytanieAnkieta_PytanieId",
                table: "PytanieAnkieta",
                column: "PytanieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PytanieAnkieta");

            migrationBuilder.DropTable(
                name: "Ankieta");

            migrationBuilder.DropTable(
                name: "Pytanie");

            migrationBuilder.DropTable(
                name: "OdpowiedzUzytkownika");

            migrationBuilder.DropTable(
                name: "Odpowiedz");

            migrationBuilder.DropTable(
                name: "Uzytkownik");
        }
    }
}
