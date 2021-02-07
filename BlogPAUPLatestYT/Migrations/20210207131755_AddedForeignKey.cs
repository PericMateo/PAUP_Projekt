using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPAUPLatestYT.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdentityUserId",
                table: "Posts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_IdentityUserId",
                table: "Posts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_IdentityUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_IdentityUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Posts");
        }
    }
}
