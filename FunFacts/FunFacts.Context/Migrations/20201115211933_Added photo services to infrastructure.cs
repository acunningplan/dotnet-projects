using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FunFacts.Context.Migrations
{
    public partial class Addedphotoservicestoinfrastructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunFactImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunFactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ImgurId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProfilePictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ImgurId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePictures_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunFactImages_FunFactId",
                table: "FunFactImages",
                column: "FunFactId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePictures_AppUserId",
                table: "ProfilePictures",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunFactImages");

            migrationBuilder.DropTable(
                name: "ProfilePictures");
        }
    }
}
