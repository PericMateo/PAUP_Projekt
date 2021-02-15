using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPAUPLatestYT.Migrations
{
    public partial class TryingCustomForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazivKreatora",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivKreatora",
                table: "Posts");
        }
    }
}
