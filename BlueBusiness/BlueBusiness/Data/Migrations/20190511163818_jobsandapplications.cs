using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBusiness.Data.Migrations
{
    public partial class jobsandapplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobsID",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobsID",
                table: "Applications",
                column: "JobsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobsID",
                table: "Applications",
                column: "JobsID",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobsID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobsID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "JobsID",
                table: "Applications");
        }
    }
}
