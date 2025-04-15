using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STFSTUDSTATUS",
                table: "StudentFiles",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "STFSTUDREMARKS",
                table: "StudentFiles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15);

            migrationBuilder.CreateTable(
                name: "SubjectFiles",
                columns: table => new
                {
                    SFSUBJCODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SFSUBJCOURSECODE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SFSUBJDESC = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SFSUBJUNITS = table.Column<float>(type: "real", nullable: false),
                    SFSUBJREGOFRNG = table.Column<int>(type: "int", nullable: false),
                    SFSUBJCATEGORY = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SFSUBJSTATUS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SFSUBJCURRCODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectFiles", x => new { x.SFSUBJCODE, x.SFSUBJCOURSECODE });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectFiles");

            migrationBuilder.AlterColumn<int>(
                name: "STFSTUDSTATUS",
                table: "StudentFiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "STFSTUDREMARKS",
                table: "StudentFiles",
                type: "int",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
