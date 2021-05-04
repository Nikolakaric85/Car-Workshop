using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class addColumntToCategoryItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ServiceItems");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ServiceItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ServiceItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ServiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
