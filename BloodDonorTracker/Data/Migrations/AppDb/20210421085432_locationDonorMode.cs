using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class locationDonorMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocationUpdateAuto",
                table: "Donors",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocationUpdateAuto",
                table: "Donors");
        }
    }
}
