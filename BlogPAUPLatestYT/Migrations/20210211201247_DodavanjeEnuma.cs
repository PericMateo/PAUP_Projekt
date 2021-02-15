using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPAUPLatestYT.Migrations
{
    public partial class DodavanjeEnuma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CeollegeDirections",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CeollegeDirections",
                table: "Posts");
        }
    }
}
