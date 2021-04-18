using Microsoft.EntityFrameworkCore.Migrations;

namespace Tefter.Migrations
{
    public partial class ChangedOtherServicesPropTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceCheck",
                table: "OtherServices");

            migrationBuilder.AlterColumn<string>(
                name: "Kilometers",
                table: "OtherServices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ServiceMade",
                table: "OtherServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceMade",
                table: "OtherServices");

            migrationBuilder.AlterColumn<int>(
                name: "Kilometers",
                table: "OtherServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceCheck",
                table: "OtherServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
