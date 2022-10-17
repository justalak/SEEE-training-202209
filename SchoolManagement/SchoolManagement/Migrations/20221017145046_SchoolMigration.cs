using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class SchoolMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classInfos",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: false),
                    ClassQuantity = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classInfos", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "studentInfos",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: false),
                    StudentGender = table.Column<int>(nullable: false),
                    StudentEmail = table.Column<string>(nullable: true),
                    StudentPhoneNumber = table.Column<string>(nullable: true),
                    StudentScore = table.Column<float>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentInfos", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "teacherInfos",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(nullable: false),
                    TeacherGender = table.Column<string>(nullable: true),
                    TeacherEmail = table.Column<string>(nullable: true),
                    TeacherPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherInfos", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classInfos");

            migrationBuilder.DropTable(
                name: "studentInfos");

            migrationBuilder.DropTable(
                name: "teacherInfos");
        }
    }
}
