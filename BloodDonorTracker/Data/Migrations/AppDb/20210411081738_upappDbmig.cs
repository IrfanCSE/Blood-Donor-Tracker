using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class upappDbmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Donors_DonorIdFk",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_DonorIdFk",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "DonorIdFk",
                table: "Alerts",
                newName: "RequestIdFk");

            migrationBuilder.AlterColumn<long>(
                name: "AdminDonorIdFk",
                table: "Admins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_RequestDonorFk",
                table: "BloodRequests",
                column: "RequestDonorFk");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_ResponsedDonorFk",
                table: "BloodRequests",
                column: "ResponsedDonorFk");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_DonorIdFk",
                table: "BlackLists",
                column: "DonorIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_RequestIdFk",
                table: "Alerts",
                column: "RequestIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminDonorIdFk",
                table: "Admins",
                column: "AdminDonorIdFk",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Donors_AdminDonorIdFk",
                table: "Admins",
                column: "AdminDonorIdFk",
                principalTable: "Donors",
                principalColumn: "DonorIdPk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_BloodRequests_RequestIdFk",
                table: "Alerts",
                column: "RequestIdFk",
                principalTable: "BloodRequests",
                principalColumn: "BloodRequestIdPk",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlackLists_Donors_DonorIdFk",
                table: "BlackLists",
                column: "DonorIdFk",
                principalTable: "Donors",
                principalColumn: "DonorIdPk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Donors_RequestDonorFk",
                table: "BloodRequests",
                column: "RequestDonorFk",
                principalTable: "Donors",
                principalColumn: "DonorIdPk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodRequests_Donors_ResponsedDonorFk",
                table: "BloodRequests",
                column: "ResponsedDonorFk",
                principalTable: "Donors",
                principalColumn: "DonorIdPk",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Donors_AdminDonorIdFk",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_BloodRequests_RequestIdFk",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_BlackLists_Donors_DonorIdFk",
                table: "BlackLists");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Donors_RequestDonorFk",
                table: "BloodRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodRequests_Donors_ResponsedDonorFk",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_RequestDonorFk",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_ResponsedDonorFk",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BlackLists_DonorIdFk",
                table: "BlackLists");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_RequestIdFk",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Admins_AdminDonorIdFk",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "RequestIdFk",
                table: "Alerts",
                newName: "DonorIdFk");

            migrationBuilder.AlterColumn<string>(
                name: "AdminDonorIdFk",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_DonorIdFk",
                table: "Alerts",
                column: "DonorIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Donors_DonorIdFk",
                table: "Alerts",
                column: "DonorIdFk",
                principalTable: "Donors",
                principalColumn: "DonorIdPk",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
