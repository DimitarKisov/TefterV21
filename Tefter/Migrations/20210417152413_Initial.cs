using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tefter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ChassisNumber = table.Column<string>(nullable: true),
                    EngineNumber = table.Column<string>(nullable: true),
                    WorkingVolumeCubicCm = table.Column<int>(nullable: false),
                    FirstRegisterDate = table.Column<DateTime>(nullable: false),
                    FirstRegisterDateInBg = table.Column<DateTime>(nullable: false),
                    FuelType = table.Column<int>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Egn = table.Column<string>(nullable: true),
                    Bulstat = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDatas_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilAndFilters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilAndFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilAndFilters_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Kilometers = table.Column<int>(nullable: false),
                    ServiceCheck = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherServices_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarExtras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abs = table.Column<bool>(nullable: false),
                    Asd = table.Column<bool>(nullable: false),
                    Ebs = table.Column<bool>(nullable: false),
                    Arb = table.Column<bool>(nullable: false),
                    Esp = table.Column<bool>(nullable: false),
                    FourByFour = table.Column<bool>(nullable: false),
                    AirConditioning = table.Column<bool>(nullable: false),
                    Climatronic = table.Column<bool>(nullable: false),
                    Hatch = table.Column<bool>(nullable: false),
                    Alarm = table.Column<bool>(nullable: false),
                    Immobilizer = table.Column<bool>(nullable: false),
                    CentralLocking = table.Column<bool>(nullable: false),
                    ElectronicGlass = table.Column<bool>(nullable: false),
                    ElectronicMirrors = table.Column<bool>(nullable: false),
                    Automatic = table.Column<bool>(nullable: false),
                    ElectronicPacket = table.Column<bool>(nullable: false),
                    SteeringWheelHydraulics = table.Column<bool>(nullable: false),
                    Stereo = table.Column<bool>(nullable: false),
                    CdChanger = table.Column<bool>(nullable: false),
                    Amplifier = table.Column<bool>(nullable: false),
                    Other = table.Column<string>(nullable: true),
                    CarDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarExtras_CarDatas_CarDataId",
                        column: x => x.CarDataId,
                        principalTable: "CarDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDatas_CarId",
                table: "CarDatas",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_CarDataId",
                table: "CarExtras",
                column: "CarDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OilAndFilters_CarId",
                table: "OilAndFilters",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherServices_CarId",
                table: "OtherServices",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarExtras");

            migrationBuilder.DropTable(
                name: "OilAndFilters");

            migrationBuilder.DropTable(
                name: "OtherServices");

            migrationBuilder.DropTable(
                name: "CarDatas");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
