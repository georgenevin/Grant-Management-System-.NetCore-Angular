using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class NewTableGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grants",
                columns: table => new
                {
                    GrantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grants", x => x.GrantId);
                });
        }
    }
}
