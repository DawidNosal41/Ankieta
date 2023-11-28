using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ankieta.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OdpowiedzUzytkownika");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OdpowiedzUzytkownika",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
