using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class InitialCreateeducationdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("ApplicationId", "EducationDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
