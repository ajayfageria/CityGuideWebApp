using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class addingByteArrayImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "EnitityImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "EnitityImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "EnitityImages");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "EnitityImages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
