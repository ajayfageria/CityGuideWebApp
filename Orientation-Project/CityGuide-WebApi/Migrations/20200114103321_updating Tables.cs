using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class updatingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterTable_Categories_CategoryId",
                table: "MasterTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterTable",
                table: "MasterTable");

            migrationBuilder.RenameTable(
                name: "MasterTable",
                newName: "BaseTable");

            migrationBuilder.RenameIndex(
                name: "IX_MasterTable_CategoryId",
                table: "BaseTable",
                newName: "IX_BaseTable_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseTable",
                table: "BaseTable",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseTable_Categories_CategoryId",
                table: "BaseTable",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseTable_Categories_CategoryId",
                table: "BaseTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseTable",
                table: "BaseTable");

            migrationBuilder.RenameTable(
                name: "BaseTable",
                newName: "MasterTable");

            migrationBuilder.RenameIndex(
                name: "IX_BaseTable_CategoryId",
                table: "MasterTable",
                newName: "IX_MasterTable_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterTable",
                table: "MasterTable",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTable_Categories_CategoryId",
                table: "MasterTable",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
