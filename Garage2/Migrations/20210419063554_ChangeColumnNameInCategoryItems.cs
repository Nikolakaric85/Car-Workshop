using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage2.Migrations
{
    public partial class ChangeColumnNameInCategoryItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_ServiceCategories_CategoryId",
                table: "CategoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_ServiceItems_ItemId",
                table: "CategoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_CategoryId",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_ItemId",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "CategoryItemsId",
                table: "CategoryItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoryItems",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryCategoryId",
                table: "CategoryItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceItemItemId",
                table: "CategoryItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ServiceCategoryCategoryId",
                table: "CategoryItems",
                column: "ServiceCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ServiceItemItemId",
                table: "CategoryItems",
                column: "ServiceItemItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_ServiceCategories_ServiceCategoryCategoryId",
                table: "CategoryItems",
                column: "ServiceCategoryCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_ServiceItems_ServiceItemItemId",
                table: "CategoryItems",
                column: "ServiceItemItemId",
                principalTable: "ServiceItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_ServiceCategories_ServiceCategoryCategoryId",
                table: "CategoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_ServiceItems_ServiceItemItemId",
                table: "CategoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_ServiceCategoryCategoryId",
                table: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItems_ServiceItemItemId",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryCategoryId",
                table: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "ServiceItemItemId",
                table: "CategoryItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryItemsId",
                table: "CategoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems",
                column: "CategoryItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryId",
                table: "CategoryItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ItemId",
                table: "CategoryItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_ServiceCategories_CategoryId",
                table: "CategoryItems",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_ServiceItems_ItemId",
                table: "CategoryItems",
                column: "ItemId",
                principalTable: "ServiceItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
