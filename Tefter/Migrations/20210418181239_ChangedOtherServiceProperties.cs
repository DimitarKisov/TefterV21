using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tefter.Migrations
{
    public partial class ChangedOtherServiceProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "OtherServices");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "OtherServices");

            migrationBuilder.DropColumn(
                name: "ServiceMade",
                table: "OtherServices");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "OtherServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "OtherServices");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "OtherServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Kilometers",
                table: "OtherServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceMade",
                table: "OtherServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
