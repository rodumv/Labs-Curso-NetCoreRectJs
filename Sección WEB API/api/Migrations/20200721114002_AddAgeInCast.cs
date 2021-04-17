using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddAgeInCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Casts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Casts");
        }
    }
}
