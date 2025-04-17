using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateEnrollmentHeaderFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrollmentHeaderFiles",
                columns: table => new
                {
                    ENRHFSTUDID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENRHFSTUDDATEENROLL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENRHFSTUDSCHLYR = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ENRHFSTUDENCODER = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ENRHFSTUDTOTALUNITS = table.Column<double>(type: "float", nullable: false),
                    ENRHFSTUDSTATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentHeaderFiles", x => x.ENRHFSTUDID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentHeaderFiles");
        }
    }
}
