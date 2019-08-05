using Microsoft.EntityFrameworkCore.Migrations;

namespace TAVSS.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupModelId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TAs_Courses_CourseModelId",
                table: "TAs");

            migrationBuilder.DropIndex(
                name: "IX_TAs_CourseModelId",
                table: "TAs");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupModelId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseModelId",
                table: "TAs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "TAs");

            migrationBuilder.DropColumn(
                name: "ConfirmPassWord",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupModelId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "CourseTAModel",
                columns: table => new
                {
                    CId = table.Column<int>(nullable: false),
                    TId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true),
                    TAId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTAModel", x => new { x.CId, x.TId });
                    table.ForeignKey(
                        name: "FK_CourseTAModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTAModel_TAs_TAId",
                        column: x => x.TAId,
                        principalTable: "TAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroupModel",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false),
                    GId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroupModel", x => new { x.SId, x.GId });
                    table.ForeignKey(
                        name: "FK_StudentGroupModel_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentGroupModel_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTAModel_CourseId",
                table: "CourseTAModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTAModel_TAId",
                table: "CourseTAModel",
                column: "TAId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupModel_GroupId",
                table: "StudentGroupModel",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupModel_StudentId",
                table: "StudentGroupModel",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTAModel");

            migrationBuilder.DropTable(
                name: "StudentGroupModel");

            migrationBuilder.AddColumn<int>(
                name: "CourseModelId",
                table: "TAs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TAs",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassWord",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupModelId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TAs_CourseModelId",
                table: "TAs",
                column: "CourseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupModelId",
                table: "Students",
                column: "GroupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupModelId",
                table: "Students",
                column: "GroupModelId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAs_Courses_CourseModelId",
                table: "TAs",
                column: "CourseModelId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
