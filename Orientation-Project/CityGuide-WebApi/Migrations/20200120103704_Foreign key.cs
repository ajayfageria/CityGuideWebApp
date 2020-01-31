using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class Foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationAmenities_BaseTable_BaseTableID",
                table: "AccommodationAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiesAmenities_BaseTable_BaseTableID",
                table: "ActivitiesAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodAmenities_BaseTable_BaseTableID",
                table: "FoodAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristsAmenities_BaseTable_BaseTableID",
                table: "TouristsAmenities");

            migrationBuilder.DropIndex(
                name: "IX_TouristsAmenities_BaseTableID",
                table: "TouristsAmenities");

            migrationBuilder.DropIndex(
                name: "IX_FoodAmenities_BaseTableID",
                table: "FoodAmenities");

            migrationBuilder.DropIndex(
                name: "IX_ActivitiesAmenities_BaseTableID",
                table: "ActivitiesAmenities");

            migrationBuilder.DropIndex(
                name: "IX_AccommodationAmenities_BaseTableID",
                table: "AccommodationAmenities");

            migrationBuilder.DropColumn(
                name: "BaseTableID",
                table: "TouristsAmenities");

            migrationBuilder.DropColumn(
                name: "BaseTableID",
                table: "FoodAmenities");

            migrationBuilder.DropColumn(
                name: "BaseTableID",
                table: "ActivitiesAmenities");

            migrationBuilder.DropColumn(
                name: "BaseTableID",
                table: "AccommodationAmenities");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationAmenities_BaseTable_Id",
                table: "AccommodationAmenities",
                column: "Id",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesAmenities_BaseTable_Id",
                table: "ActivitiesAmenities",
                column: "Id",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodAmenities_BaseTable_Id",
                table: "FoodAmenities",
                column: "Id",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristsAmenities_BaseTable_Id",
                table: "TouristsAmenities",
                column: "Id",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationAmenities_BaseTable_Id",
                table: "AccommodationAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitiesAmenities_BaseTable_Id",
                table: "ActivitiesAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodAmenities_BaseTable_Id",
                table: "FoodAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristsAmenities_BaseTable_Id",
                table: "TouristsAmenities");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseTableID",
                table: "TouristsAmenities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseTableID",
                table: "FoodAmenities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseTableID",
                table: "ActivitiesAmenities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BaseTableID",
                table: "AccommodationAmenities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristsAmenities_BaseTableID",
                table: "TouristsAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAmenities_BaseTableID",
                table: "FoodAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAmenities_BaseTableID",
                table: "ActivitiesAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationAmenities_BaseTableID",
                table: "AccommodationAmenities",
                column: "BaseTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationAmenities_BaseTable_BaseTableID",
                table: "AccommodationAmenities",
                column: "BaseTableID",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesAmenities_BaseTable_BaseTableID",
                table: "ActivitiesAmenities",
                column: "BaseTableID",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodAmenities_BaseTable_BaseTableID",
                table: "FoodAmenities",
                column: "BaseTableID",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristsAmenities_BaseTable_BaseTableID",
                table: "TouristsAmenities",
                column: "BaseTableID",
                principalTable: "BaseTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
