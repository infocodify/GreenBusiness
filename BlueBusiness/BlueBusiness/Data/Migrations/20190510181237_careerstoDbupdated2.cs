using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBusiness.Data.Migrations
{
    public partial class careerstoDbupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BriefDescription",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BriefDescription",
                table: "Jobs");
        }
    }
}
