using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumMedStore.Migrations
{
    public partial class LastLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkName",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "LinkName",
                table: "Vacancies");
        }
    }
}
