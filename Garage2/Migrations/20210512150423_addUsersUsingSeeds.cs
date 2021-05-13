using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class addUsersUsingSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "787f027d-1c56-4b3e-b0ed-3fe2d7c7efa3", "Admin", "ADMIN" },
                    { "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8", "4e575724-d997-4b7a-a14d-50ea627f18ce", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LicencePlate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "12b52da7-83c3-46b2-96f1-f4424e1bd1ec", "admin@gmail.com", false, "Admin", "SD-000-XX", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEGHyc05WV4uZbAGRD47B/jyyRA6QgYYO1hE2tSbQP6eJQ6N+rvDF3nknbWFdbKYahw==", null, false, "Admin", "c38442bc-3c46-4408-8b5e-600e834857b3", false, "Admin" },
                    { "165412e8-86ab-4ade-b351-75494216e814", 0, "852a51cb-9eec-4862-954c-02a768db999e", "user@gmail.com", false, "User", "SD-000-XX", false, null, "USER@GMAIL.COM", "USER", "AQAAAAEAACcQAAAAEF+VLqyfR2ppyo0Uzsxd6DMtyEtAq4RFqGkHJ8+vHmYhRYk5wBTjFwrRSd0cZdiKzA==", null, false, "User", "39323b16-7d98-460b-b969-d81d7b17c428", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "165412e8-86ab-4ade-b351-75494216e814", "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "165412e8-86ab-4ade-b351-75494216e814", "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35b6367-1ecf-4ade-9e3b-85b81b55e4a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "165412e8-86ab-4ade-b351-75494216e814");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }
    }
}
