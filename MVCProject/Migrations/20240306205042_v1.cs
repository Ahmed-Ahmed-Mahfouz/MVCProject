using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    minDegree = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crsResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crsResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_crsResult_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_crsResult_Trainee_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", "IT" },
                    { 2, "Ali", "HR" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Degree", "DepartmentId", "Name", "minDegree" },
                values: new object[,]
                {
                    { 1, 100, 1, "C#", 60 },
                    { 2, 100, 1, "Java", 60 },
                    { 3, 100, 2, "HR", 60 }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Address", "CourseId", "DepartmentId", "ImageURL", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", null, 1, "4.jpg", "Mohamed", 10000m },
                    { 2, "Giza", null, 1, "5.jpg", "Ahmed", 8000m },
                    { 3, "Alex", null, 2, "6.jpg", "Ali", 7500m }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentId", "Grade", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 2, "1.jpg", "Abdallah" },
                    { 2, "Giza", 1, 2, "2.jpg", "Shadi" },
                    { 3, "Alex", 2, 3, "3.jpg", "Eslam" }
                });

            migrationBuilder.InsertData(
                table: "crsResult",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, null, 50, 1 },
                    { 2, null, 80, 2 },
                    { 3, null, 70, 3 },
                    { 4, null, 90, 1 },
                    { 5, null, 40, 2 },
                    { 6, null, 70, 3 },
                    { 7, null, 60, 1 },
                    { 8, null, 80, 2 },
                    { 9, null, 30, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_crsResult_CourseId",
                table: "crsResult",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_crsResult_TraineeId",
                table: "crsResult",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_CourseId",
                table: "Instructor",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentId",
                table: "Instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DepartmentId",
                table: "Trainee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crsResult");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
