using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class AddeddeleteHashpropertyinImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleteHash",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteHash",
                table: "Images");
        }
    }
}
