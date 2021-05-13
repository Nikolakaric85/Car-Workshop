using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class RenameChassisNumberToEngineNumberAndRemoveServiceIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Cars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e204c767-3270-49ab-8336-16c66885fa67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8",
                column: "ConcurrencyStamp",
                value: "7bf07aa6-3ea8-4b80-b88d-f8b0a13df827");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "165412e8-86ab-4ade-b351-75494216e814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54361c94-c9f4-47d0-b8e0-de13e0ac5558", "AQAAAAEAACcQAAAAEJTrZ+HRohrXXs8UXgcNL//JXVK4qqHhhuF/UopM4YzMe+HqmFayQMsNhSYgvMa8qA==", "ef036877-351c-455a-82b3-009a212addaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d57dcf6-c941-4ace-b925-c06f545426f8", "AQAAAAEAACcQAAAAEMXM+TpHNJlHcfOU+6DbKL3/hCEEMyV9TQ7V9figxEZ+hseQT+5LjuY7opnPMzf0nw==", "bc2a3e0c-7745-4103-8750-0ee82882c6dc" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "EngineDisplacement", "EngineNumber", "EnginePower", "FuelType", "IsActive", "LicencePlate", "Model", "UserId", "VinNumber", "Year" },
                values: new object[,]
                {
                    { 1, 1242, "188A4000B6531651", 60, "Petrol", true, "SD-000-XX", "Fiat Punto", "8e445865-a24d-4543-a6c6-9443d048cdb9", "SFGDGF54164165", 2005 },
                    { 2, 689, "15616DSFCDSW", 75, "Petrol", true, "SD-00-000", "Yamaha MT-07", "8e445865-a24d-4543-a6c6-9443d048cdb9", "56161616DSGVFDS", 2014 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "CategoryId", "Category" },
                values: new object[,]
                {
                    { 1, "Oil Change" },
                    { 2, "Timing Belt" },
                    { 3, "Wheel Aligment" }
                });

            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "ItemId", "Category", "CategoryId", "Item" },
                values: new object[,]
                {
                    { 1, "Oil Change", 1, "Air Filter" },
                    { 2, "Oil Change", 1, "Oil Filter" },
                    { 3, "Oil Change", 1, "Cabin Filter" },
                    { 4, "Oil Change", 1, "Fuel Filter" },
                    { 5, "Timing Belt", 2, "Water Pump" },
                    { 6, "Timing Belt", 2, "PK Belt" },
                    { 7, "Wheel Aligment", 3, "Wheel Aligment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ab8de626-e224-4f35-ae13-2661be0ba8b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8",
                column: "ConcurrencyStamp",
                value: "8ee69d2f-9368-49dd-bab0-047493c68681");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "165412e8-86ab-4ade-b351-75494216e814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14412c60-46ea-4411-bb80-8de850971902", "AQAAAAEAACcQAAAAEND/0SVEDxo7D1WMOLso94woR09/Iu3LTnBE+oLm7oMhRTVd9EpV9az2w7Jof1lNag==", "459fdc1b-2a96-4191-8941-847acf241bf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dad3fbc5-869c-48e3-b5f9-10a9d8ffecdb", "AQAAAAEAACcQAAAAENUyjwTue3GLNA1x9+oRpjFAT2mPs/QuGQfpZmg3cDflJBDk9tUMaqCa9hEmTaoClA==", "55e18759-e45c-46ad-adbc-034569065df4" });
        }
    }
}
