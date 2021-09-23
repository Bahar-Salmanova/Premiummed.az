using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumMedStore.Migrations
{
    public partial class AddEmailProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "VacancyForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "VacancyForms");
        }
    }
}
