using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityGuide_WebApi.Migrations
{
    public partial class removingID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasElevator = table.Column<int>(type: "int", nullable: false),
                    HasFitnessFacilities = table.Column<int>(type: "int", nullable: false),
                    HasInternet = table.Column<int>(type: "int", nullable: false),
                    HasMeetingRooms = table.Column<int>(type: "int", nullable: false),
                    HasParking = table.Column<int>(type: "int", nullable: false),
                    HasSecurityGaurd = table.Column<int>(type: "int", nullable: false),
                    HasSwimmingPool = table.Column<int>(type: "int", nullable: false),
                    HasTv = table.Column<int>(type: "int", nullable: false),
                    LuxeryLevel = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasElevator = table.Column<int>(type: "int", nullable: false),
                    HasWashroomFacilities = table.Column<int>(type: "int", nullable: false),
                    NoOfHoursTaken = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FoodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasFoodPackaging = table.Column<int>(type: "int", nullable: false),
                    HasFoodStalls = table.Column<int>(type: "int", nullable: false),
                    HasNonveg = table.Column<int>(type: "int", nullable: false),
                    HasOnlineDelivery = table.Column<int>(type: "int", nullable: false),
                    HasVeg = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasElevator = table.Column<int>(type: "int", nullable: false),
                    HasMedical = table.Column<int>(type: "int", nullable: false),
                    HasPark = table.Column<int>(type: "int", nullable: false),
                    HasParking = table.Column<int>(type: "int", nullable: false),
                    HasSwimmingPool = table.Column<int>(type: "int", nullable: false),
                    HasTrekking = table.Column<int>(type: "int", nullable: false),
                    HasWifi = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false)
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
    }
}
