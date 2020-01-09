using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CorrectIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripCards",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "TripCards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Beautiful City!", "Munich" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "TripCards",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1L, "Beautiful City!", "Munich" });
        }
    }
}
