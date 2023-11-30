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
                name: "AnkietaSzkolna",
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
                    table.PrimaryKey("PK_AnkietaSzkolna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzytkownikUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzytkownik_AspNetUsers_UzytkownikUserId",
                        column: x => x.UzytkownikUserId,
                        principalTable: "AspNetUsers",
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
                    AnkietaSzkolnaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pytanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pytanie_AnkietaSzkolna_AnkietaSzkolnaId",
                        column: x => x.AnkietaSzkolnaId,
                        principalTable: "AnkietaSzkolna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odpowiedz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PytanieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odpowiedz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odpowiedz_Pytanie_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdpowiedzUzytkownika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PytanieId = table.Column<int>(type: "int", nullable: false),
                    OdpowiedzId = table.Column<int>(type: "int", nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_OdpowiedzUzytkownika_Pytanie_PytanieId",
                        column: x => x.PytanieId,
                        principalTable: "Pytanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdpowiedzUzytkownika_Uzytkownik_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odpowiedz_PytanieId",
                table: "Odpowiedz",
                column: "PytanieId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedzUzytkownika_OdpowiedzId",
                table: "OdpowiedzUzytkownika",
                column: "OdpowiedzId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedzUzytkownika_PytanieId",
                table: "OdpowiedzUzytkownika",
                column: "PytanieId");

            migrationBuilder.CreateIndex(
                name: "IX_OdpowiedzUzytkownika_UzytkownikId",
                table: "OdpowiedzUzytkownika",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pytanie_AnkietaSzkolnaId",
                table: "Pytanie",
                column: "AnkietaSzkolnaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_UzytkownikUserId",
                table: "Uzytkownik",
                column: "UzytkownikUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdpowiedzUzytkownika");

            migrationBuilder.DropTable(
                name: "Odpowiedz");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "Pytanie");

            migrationBuilder.DropTable(
                name: "AnkietaSzkolna");
        }
    }
}
