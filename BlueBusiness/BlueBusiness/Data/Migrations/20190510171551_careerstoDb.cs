using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBusiness.Data.Migrations
{
    public partial class careerstoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateApplied = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    EmploymentEligibility = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Ethnicity = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    JobDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CompanyDescription = table.Column<string>(nullable: true),
                    ResponsibilityOne = table.Column<string>(nullable: true),
                    ResponsibilityTwo = table.Column<string>(nullable: true),
                    ResponsibilityThree = table.Column<string>(nullable: true),
                    ResponsibilityFour = table.Column<string>(nullable: true),
                    RequirementOne = table.Column<string>(nullable: true),
                    RequirementTwo = table.Column<string>(nullable: true),
                    RequirementThree = table.Column<string>(nullable: true),
                    RequirementFour = table.Column<string>(nullable: true),
                    Benefits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
