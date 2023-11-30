using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ankieta.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tresc",
                table: "OdpowiedzUzytkownika");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tresc",
                table: "OdpowiedzUzytkownika",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
