using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumMedStore.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telephone2",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone2",
                table: "Settings");
        }
    }
}
