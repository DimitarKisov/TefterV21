using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tefter.Migrations
{
    public partial class ChangedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExtras_CarDatas_CarDataId",
                table: "CarExtras");

            migrationBuilder.DropTable(
                name: "CarDatas");

            migrationBuilder.DropIndex(
                name: "IX_CarExtras_CarDataId",
                table: "CarExtras");

            migrationBuilder.DropColumn(
                name: "CarDataId",
                table: "CarExtras");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bulstat",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Egn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstRegisterDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstRegisterDateInBg",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kilometers",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingVolumeCubicCm",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "CarExtras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_CarId",
                table: "CarExtras",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExtras_Cars_CarId",
                table: "CarExtras");

            migrationBuilder.DropIndex(
                name: "IX_CarExtras_CarId",
                table: "CarExtras");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Bulstat",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Egn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FirstRegisterDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FirstRegisterDateInBg",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "WorkingVolumeCubicCm",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarExtras");

            migrationBuilder.AddColumn<int>(
                name: "CarDataId",
                table: "CarExtras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bulstat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstRegisterDateInBg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Kilometers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingVolumeCubicCm = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_CarDataId",
                table: "CarExtras",
                column: "CarDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDatas_CarId",
                table: "CarDatas",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExtras_CarDatas_CarDataId",
                table: "CarExtras",
                column: "CarDataId",
                principalTable: "CarDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
