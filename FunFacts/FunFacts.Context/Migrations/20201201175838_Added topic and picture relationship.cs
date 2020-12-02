using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FunFacts.Context.Migrations
{
    public partial class Addedtopicandpicturerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePictures_AspNetUsers_AppUserId",
                table: "ProfilePictures");

            migrationBuilder.DropTable(
                name: "FunFactImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures");

            migrationBuilder.RenameTable(
                name: "ProfilePictures",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_ProfilePictures_AppUserId",
                table: "Image",
                newName: "IX_Image_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FunFactId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Image",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_FunFactId",
                table: "Image",
                column: "FunFactId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TopicId",
                table: "Image",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_AppUserId",
                table: "Image",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_FunFacts_FunFactId",
                table: "Image",
                column: "FunFactId",
                principalTable: "FunFacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Topics_TopicId",
                table: "Image",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_AppUserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_FunFacts_FunFactId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Topics_TopicId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_FunFactId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_TopicId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "FunFactId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "ProfilePictures");

            migrationBuilder.RenameIndex(
                name: "IX_Image_AppUserId",
                table: "ProfilePictures",
                newName: "IX_ProfilePictures_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilePictures",
                table: "ProfilePictures",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FunFactImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeleteHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunFactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImgurId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunFactImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunFactImages_FunFacts_FunFactId",
                        column: x => x.FunFactId,
                        principalTable: "FunFacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunFactImages_FunFactId",
                table: "FunFactImages",
                column: "FunFactId");

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
