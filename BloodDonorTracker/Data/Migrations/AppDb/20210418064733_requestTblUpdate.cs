using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class requestTblUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "BloodRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "BloodRequests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "BloodRequests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "BloodRequests",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BloodRequests");
        }
    }
}
