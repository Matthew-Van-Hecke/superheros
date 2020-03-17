using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroManager.Data.Migrations
{
    public partial class AddedCatchphrase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Catchphrase",
                table: "Superheros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catchphrase",
                table: "Superheros");
        }
    }
}
