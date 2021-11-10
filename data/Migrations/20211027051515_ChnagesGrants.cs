using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class ChnagesGrants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramCode",
                table: "Grants",
                type: "nvarchar(30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramCode",
                table: "Grants");
        }
    }
}
