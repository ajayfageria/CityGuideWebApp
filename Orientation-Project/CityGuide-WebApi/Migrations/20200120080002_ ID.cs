using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationAmenities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BaseTableID = table.Column<Guid>(nullable: true),
                    HasInternet = table.Column<int>(nullable: false),
                    HasMeetingRooms = table.Column<int>(nullable: false),
                    HasFitnessFacilities = table.Column<int>(nullable: false),
                    HasParking = table.Column<int>(nullable: false),
                    HasSwimmingPool = table.Column<int>(nullable: false),
                    HasElevator = table.Column<int>(nullable: false),
                    HasSecurityGaurd = table.Column<int>(nullable: false),
                    HasTv = table.Column<int>(nullable: false),
                    LuxeryLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationAmenities_BaseTable_BaseTableID",
                        column: x => x.BaseTableID,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAmenities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BaseTableID = table.Column<Guid>(nullable: true),
                    TicketPrice = table.Column<int>(nullable: false),
                    HasElevator = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    NoOfHoursTaken = table.Column<int>(nullable: false),
                    HasWashroomFacilities = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesAmenities_BaseTable_BaseTableID",
                        column: x => x.BaseTableID,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodAmenities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BaseTableID = table.Column<Guid>(nullable: true),
                    HasFoodStalls = table.Column<int>(nullable: false),
                    HasVeg = table.Column<int>(nullable: false),
                    HasNonveg = table.Column<int>(nullable: false),
                    HasFoodPackaging = table.Column<int>(nullable: false),
                    HasOnlineDelivery = table.Column<int>(nullable: false),
                    FoodType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodAmenities_BaseTable_BaseTableID",
                        column: x => x.BaseTableID,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TouristsAmenities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BaseTableID = table.Column<Guid>(nullable: true),
                    TicketPrice = table.Column<int>(nullable: false),
                    HasWifi = table.Column<int>(nullable: false),
                    HasPark = table.Column<int>(nullable: false),
                    HasSwimmingPool = table.Column<int>(nullable: false),
                    HasParking = table.Column<int>(nullable: false),
                    HasElevator = table.Column<int>(nullable: false),
                    HasMedical = table.Column<int>(nullable: false),
                    HasTrekking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristsAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristsAmenities_BaseTable_BaseTableID",
                        column: x => x.BaseTableID,
                        principalTable: "BaseTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationAmenities_BaseTableID",
                table: "AccommodationAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAmenities_BaseTableID",
                table: "ActivitiesAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAmenities_BaseTableID",
                table: "FoodAmenities",
                column: "BaseTableID");

            migrationBuilder.CreateIndex(
                name: "IX_TouristsAmenities_BaseTableID",
                table: "TouristsAmenities",
                column: "BaseTableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationAmenities");

            migrationBuilder.DropTable(
                name: "ActivitiesAmenities");

            migrationBuilder.DropTable(
                name: "FoodAmenities");

            migrationBuilder.DropTable(
                name: "TouristsAmenities");
        }
    }
}
