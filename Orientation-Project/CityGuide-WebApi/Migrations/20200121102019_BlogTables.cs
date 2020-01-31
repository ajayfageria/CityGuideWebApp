using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class BlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedTime",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PostedBy",
                table: "Blogs",
                column: "PostedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BaseTable_PostedBy",
                table: "Blogs",
                column: "PostedBy",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BaseTable_PostedBy",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_PostedBy",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
