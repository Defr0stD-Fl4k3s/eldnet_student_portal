using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    public partial class AddEnrollmentDetailFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the EnrollmentDetailFiles table
            migrationBuilder.CreateTable(
                name: "EnrollmentDetailFiles",
                columns: table => new
                {
                    ENRDFSTUDID = table.Column<long>(type: "bigint", nullable: false),
                    ENRDFSTUDEDPCODE = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    ENRDFSTUDSUBJCDE = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    ENRDFSTUDSTATUS = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentDetailFiles", x => new { x.ENRDFSTUDID, x.ENRDFSTUDEDPCODE });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the EnrollmentDetailFiles table
            migrationBuilder.DropTable(
                name: "EnrollmentDetailFiles");
        }
    }
}
