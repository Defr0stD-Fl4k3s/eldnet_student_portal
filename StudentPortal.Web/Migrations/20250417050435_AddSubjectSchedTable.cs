using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectSchedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubjectSchedFiles",
                columns: table => new
                {
                    SSFEDPCODE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SSFSUBJCODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SSFSTARTTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFENDTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFDAYS = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SSFROOM = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SSFMAXSIZE = table.Column<int>(type: "int", nullable: false),
                    SSFCLASSSIZE = table.Column<int>(type: "int", nullable: false),
                    SSFSTATUS = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SSFXM = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SSFSECTION = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SSFSCHOOLYEAR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSchedFiles", x => x.SSFEDPCODE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectSchedFiles");
        }
    }
}
