using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class AddingBlogrelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false),
                    PostedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BaseTable_PostedBy",
                        column: x => x.PostedBy,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(nullable: true),
                    BlogId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogImages_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeOrDislike = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    BlogId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userBlogs_BaseTable_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogImages_BlogId",
                table: "blogImages",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PostedBy",
                table: "Blogs",
                column: "PostedBy");

            migrationBuilder.CreateIndex(
                name: "IX_userBlogs_BlogId",
                table: "userBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_userBlogs_UserId",
                table: "userBlogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogImages");

            migrationBuilder.DropTable(
                name: "userBlogs");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
