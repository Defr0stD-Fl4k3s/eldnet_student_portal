using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentFiles",
                columns: table => new
                {
                    STFSTUDID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STFSTUDLNAME = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    STFSTUDFNAME = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    STFSTUDMNAME = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    STFSTUDCOURSE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    STFSTUDYEAR = table.Column<int>(type: "int", nullable: false),
                    STFSTUDREMARKS = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    STFSTUDSTATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFiles", x => x.STFSTUDID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFiles");
        }
    }
}
