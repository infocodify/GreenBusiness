using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBusiness.Data.Migrations
{
    public partial class careerstoDbupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Applications");
        }
    }
}
