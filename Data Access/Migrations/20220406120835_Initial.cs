using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkaterId = table.Column<int>(type: "int", nullable: false),
                    SkateboardId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxSpeed = table.Column<float>(type: "real", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false),
                    RideTime = table.Column<int>(type: "int", nullable: false),
                    PauseTime = table.Column<int>(type: "int", nullable: false),
                    isPaused = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    JourneyID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longtitude = table.Column<float>(type: "real", nullable: false),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Positions_Journeys_JourneyID",
                        column: x => x.JourneyID,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_JourneyID",
                table: "Positions",
                column: "JourneyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Journeys");
        }
    }
}
