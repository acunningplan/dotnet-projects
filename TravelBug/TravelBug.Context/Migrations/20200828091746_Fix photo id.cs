using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class Fixphotoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserPhoto_UserPhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserPhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPhotoId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserPhoto_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId",
                principalTable: "UserPhoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserPhoto_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserPhotoId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserPhotoId",
                table: "AspNetUsers",
                column: "UserPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserPhoto_UserPhotoId",
                table: "AspNetUsers",
                column: "UserPhotoId",
                principalTable: "UserPhoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
