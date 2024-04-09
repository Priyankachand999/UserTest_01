using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTest_01.Migrations
{
    public partial class addtokeninregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Registers");
        }
    }
}
