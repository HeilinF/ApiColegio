using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiColegio.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seccion = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id_estudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    telefono = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    tutor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id_estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Cursos",
                        column: x => x.id_curso,
                        principalTable: "Courses",
                        principalColumn: "id_curso");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_corto = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.id_materia);
                    table.ForeignKey(
                        name: "FK_Materias_Cursos",
                        column: x => x.id_curso,
                        principalTable: "Courses",
                        principalColumn: "id_curso");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    id_estudiante = table.Column<int>(type: "int", nullable: false),
                    id_materia = table.Column<int>(type: "int", nullable: false),
                    calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => new { x.id_estudiante, x.id_materia });
                    table.ForeignKey(
                        name: "FK_Grades_Students",
                        column: x => x.id_estudiante,
                        principalTable: "Students",
                        principalColumn: "id_estudiante");
                    table.ForeignKey(
                        name: "FK_Grades_Subjects",
                        column: x => x.id_materia,
                        principalTable: "Subjects",
                        principalColumn: "id_materia");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id_profesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    telefono = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    id_materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id_profesor);
                    table.ForeignKey(
                        name: "FK_Profesores_Materias",
                        column: x => x.id_materia,
                        principalTable: "Subjects",
                        principalColumn: "id_materia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_id_materia",
                table: "Grades",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_Students_id_curso",
                table: "Students",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_id_curso",
                table: "Subjects",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores",
                table: "Teachers",
                column: "id_materia",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
