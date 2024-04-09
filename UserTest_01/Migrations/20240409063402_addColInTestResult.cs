using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTest_01.Migrations
{
    public partial class addColInTestResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TestResults",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TestResults");
        }
    }
}
