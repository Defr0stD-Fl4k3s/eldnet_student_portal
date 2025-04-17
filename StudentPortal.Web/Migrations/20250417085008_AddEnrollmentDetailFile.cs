using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddEnrollmentDetailFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrollmentDetailFile",
                columns: table => new
                {
                    ENRDFSTUDID = table.Column<long>(type: "bigint", nullable: false),
                    ENRDFSTUDEDPCODE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ENRDFSTUDSUBJCDE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ENRDFSTUDSTATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentDetailFile", x => new { x.ENRDFSTUDID, x.ENRDFSTUDEDPCODE });
                });

            migrationBuilder.CreateTable(
                name: "studentGradeFiles",
                columns: table => new
                {
                    SGFSTUDID = table.Column<long>(type: "bigint", nullable: false),
                    SGFSTUDEDPCODE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SGFSTUDSUBJCODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SGFSTUDSUBJGRADE = table.Column<double>(type: "float", nullable: false),
                    SGFSTUDREMARKS = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentGradeFiles", x => new { x.SGFSTUDID, x.SGFSTUDEDPCODE });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentDetailFile");

            migrationBuilder.DropTable(
                name: "studentGradeFiles");
        }
    }
}
