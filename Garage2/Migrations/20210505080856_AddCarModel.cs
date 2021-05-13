using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class AddCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    EngineDisplacement = table.Column<int>(nullable: false),
                    EnginePower = table.Column<int>(nullable: false),
                    VinNumber = table.Column<string>(nullable: true),
                    ChassisNumber = table.Column<string>(nullable: true),
                    ServicesId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LicencePlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
