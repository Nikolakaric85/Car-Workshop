using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class addCategoryIdToServiceItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ServiceItems",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ServiceItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "787f027d-1c56-4b3e-b0ed-3fe2d7c7efa3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8",
                column: "ConcurrencyStamp",
                value: "4e575724-d997-4b7a-a14d-50ea627f18ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "165412e8-86ab-4ade-b351-75494216e814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "852a51cb-9eec-4862-954c-02a768db999e", "AQAAAAEAACcQAAAAEF+VLqyfR2ppyo0Uzsxd6DMtyEtAq4RFqGkHJ8+vHmYhRYk5wBTjFwrRSd0cZdiKzA==", "39323b16-7d98-460b-b969-d81d7b17c428" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b52da7-83c3-46b2-96f1-f4424e1bd1ec", "AQAAAAEAACcQAAAAEGHyc05WV4uZbAGRD47B/jyyRA6QgYYO1hE2tSbQP6eJQ6N+rvDF3nknbWFdbKYahw==", "c38442bc-3c46-4408-8b5e-600e834857b3" });
        }
    }
}
