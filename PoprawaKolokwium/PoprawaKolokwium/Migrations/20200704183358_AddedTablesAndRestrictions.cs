using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoprawaKolokwium.Migrations
{
    public partial class AddedTablesAndRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NeedSpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighters",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighters", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "FireTrucks",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationalNumber = table.Column<string>(maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrucks", x => x.IdFiretruck);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter_Actions",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false),
                    FirefighterIdFirefighter = table.Column<int>(nullable: true),
                    ActionIdAction = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighter_Actions", x => new { x.IdFirefighter, x.IdAction });
                    table.ForeignKey(
                        name: "FK_Firefighter_Actions_Actions_ActionIdAction",
                        column: x => x.ActionIdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firefighter_Actions_Firefighters_FirefighterIdFirefighter",
                        column: x => x.FirefighterIdFirefighter,
                        principalTable: "Firefighters",
                        principalColumn: "IdFirefighter",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Firetruck_Actions",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(nullable: false),
                    IdAction = table.Column<int>(nullable: false),
                    IdFiretruckAction = table.Column<int>(nullable: false),
                    AssigmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firetruck_Actions", x => new { x.IdAction, x.IdFiretruck });
                    table.ForeignKey(
                        name: "FK_Firetruck_Actions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Firetruck_Actions_FireTrucks_IdFiretruck",
                        column: x => x.IdFiretruck,
                        principalTable: "FireTrucks",
                        principalColumn: "IdFiretruck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_Actions_ActionIdAction",
                table: "Firefighter_Actions",
                column: "ActionIdAction");

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_Actions_FirefighterIdFirefighter",
                table: "Firefighter_Actions",
                column: "FirefighterIdFirefighter");

            migrationBuilder.CreateIndex(
                name: "IX_Firetruck_Actions_IdFiretruck",
                table: "Firetruck_Actions",
                column: "IdFiretruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firefighter_Actions");

            migrationBuilder.DropTable(
                name: "Firetruck_Actions");

            migrationBuilder.DropTable(
                name: "Firefighters");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "FireTrucks");
        }
    }
}
