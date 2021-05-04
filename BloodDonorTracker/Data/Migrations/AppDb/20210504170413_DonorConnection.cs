using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class DonorConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebSocketConnectionId",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebSocketConnectionId",
                table: "Donors");
        }
    }
}
