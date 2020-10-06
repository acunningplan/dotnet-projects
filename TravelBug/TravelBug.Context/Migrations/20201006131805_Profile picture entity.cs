using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class Profilepictureentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfilePictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });


            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePictures_AspNetUsers_AppUserId",
                table: "ProfilePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures");

            migrationBuilder.RenameTable(
                name: "ProfilePictures",
                newName: "UserPictures");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePictures_AppUserId",
                table: "UserPictures",
                newName: "IX_UserPictures_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_AspNetUsers_AppUserId",
                table: "UserPictures",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_AspNetUsers_AppUserId",
                table: "UserPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPictures",
                table: "UserPictures");

            migrationBuilder.RenameTable(
                name: "UserPictures",
                newName: "ProfilePictures");

            migrationBuilder.RenameIndex(
                name: "IX_UserPictures_AppUserId",
                table: "ProfilePictures",
                newName: "IX_ProfilePictures_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePictures_AspNetUsers_AppUserId",
                table: "ProfilePictures",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
