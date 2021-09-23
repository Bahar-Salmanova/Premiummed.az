using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumMedStore.Migrations
{
    public partial class LastChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullAbout",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo1",
                table: "Galeries",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo2",
                table: "Galeries",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullAbout",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Photo1",
                table: "Galeries");

            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "Galeries");
        }
    }
}
