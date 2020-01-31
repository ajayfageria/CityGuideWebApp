using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class AddingImagestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnitityImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityID = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnitityImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnitityImages_BaseTable_EntityID",
                        column: x => x.EntityID,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnitityImages_EntityID",
                table: "EnitityImages",
                column: "EntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnitityImages");
        }
    }
}
