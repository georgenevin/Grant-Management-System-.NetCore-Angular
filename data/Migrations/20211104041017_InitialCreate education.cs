using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class InitialCreateeducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail");

            migrationBuilder.AlterColumn<int>(
                name: "GrantId",
                table: "ApplicationDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EducationDetails",
                columns: table => new
                {
                    EducationalDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearofCompletion = table.Column<int>(type: "int", nullable: false),
                    ApplicantModelApplicantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDetails", x => x.EducationalDetailId);
                    table.ForeignKey(
                        name: "FK_EducationDetails_ApplicationDetail_ApplicantModelApplicantId",
                        column: x => x.ApplicantModelApplicantId,
                        principalTable: "ApplicationDetail",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationDetails_ApplicantModelApplicantId",
                table: "EducationDetails",
                column: "ApplicantModelApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail",
                column: "GrantId",
                principalTable: "GrantPrograms",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail");

            migrationBuilder.DropTable(
                name: "EducationDetails");

            migrationBuilder.AlterColumn<int>(
                name: "GrantId",
                table: "ApplicationDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetail_GrantPrograms_GrantId",
                table: "ApplicationDetail",
                column: "GrantId",
                principalTable: "GrantPrograms",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
