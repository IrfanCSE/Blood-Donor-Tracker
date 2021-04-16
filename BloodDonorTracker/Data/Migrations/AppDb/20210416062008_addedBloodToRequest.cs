using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class addedBloodToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BloodGroupFK",
                table: "BloodRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsResponsed",
                table: "BloodRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_BloodGroupFK",
                table: "BloodRequests",
                column: "BloodGroupFK");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_BloodGroups_BloodGroupFK",
                table: "BloodRequests",
                column: "BloodGroupFK",
                principalTable: "BloodGroups",
                principalColumn: "BloodGroupIdPk",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_BloodGroups_BloodGroupFK",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_BloodGroupFK",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "BloodGroupFK",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "IsResponsed",
                table: "BloodRequests");
        }
    }
}
