using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    public partial class donorRequestTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonorRequests",
                columns: table => new
                {
                    DonorRequestIdPk = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodRequestIdFk = table.Column<long>(type: "bigint", nullable: false),
                    RequestUserIdFk = table.Column<long>(type: "bigint", nullable: false),
                    RequestDonorIdFk = table.Column<long>(type: "bigint", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: true),
                    isAccept = table.Column<bool>(type: "bit", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorRequests", x => x.DonorRequestIdPk);
                    table.ForeignKey(
                        name: "FK_DonorRequests_BloodRequests_BloodRequestIdFk",
                        column: x => x.BloodRequestIdFk,
                        principalTable: "BloodRequests",
                        principalColumn: "BloodRequestIdPk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonorRequests_Donors_RequestDonorIdFk",
                        column: x => x.RequestDonorIdFk,
                        principalTable: "Donors",
                        principalColumn: "DonorIdPk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonorRequests_Donors_RequestUserIdFk",
                        column: x => x.RequestUserIdFk,
                        principalTable: "Donors",
                        principalColumn: "DonorIdPk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorRequests_BloodRequestIdFk",
                table: "DonorRequests",
                column: "BloodRequestIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_DonorRequests_RequestDonorIdFk",
                table: "DonorRequests",
                column: "RequestDonorIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_DonorRequests_RequestUserIdFk",
                table: "DonorRequests",
                column: "RequestUserIdFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorRequests");
        }
    }
}
