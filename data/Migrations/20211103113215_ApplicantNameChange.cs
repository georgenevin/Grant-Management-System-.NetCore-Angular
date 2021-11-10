using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class ApplicantNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_GrantPrograms_GrantId",
                table: "ApplicantModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantModel",
                table: "ApplicantModel");

            migrationBuilder.RenameTable(
                name: "ApplicantModel",
                newName: "ApplicationDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModel_GrantId",
                table: "ApplicationDetail",
                newName: "IX_ApplicationDetail_GrantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationDetail",
                table: "ApplicationDetail",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail",
                column: "GrantId",
                principalTable: "GrantPrograms",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationDetail",
                table: "ApplicationDetail");

            migrationBuilder.RenameTable(
                name: "ApplicationDetail",
                newName: "ApplicantModel");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationDetail_GrantId",
                table: "ApplicantModel",
                newName: "IX_ApplicantModel_GrantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantModel",
                table: "ApplicantModel",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_GrantPrograms_GrantId",
                table: "ApplicantModel",
                column: "GrantId",
                principalTable: "GrantPrograms",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
