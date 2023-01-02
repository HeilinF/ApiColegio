using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiColegio.Migrations
{
    public partial class Refactorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Cursos",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Materias",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Teachers",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Teachers",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Teachers",
                newName: "NumeroDeTelefono");

            migrationBuilder.RenameColumn(
                name: "id_materia",
                table: "Teachers",
                newName: "MateriaId");

            migrationBuilder.RenameColumn(
                name: "fecha_nacimiento",
                table: "Teachers",
                newName: "FechaDeNacimiento");

            migrationBuilder.RenameColumn(
                name: "id_profesor",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nombre_corto",
                table: "Subjects",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "id_curso",
                table: "Subjects",
                newName: "CursoId");

            migrationBuilder.RenameColumn(
                name: "id_materia",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_id_curso",
                table: "Subjects",
                newName: "IX_Subjects_CursoId");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDeTelefono",
                table: "Teachers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(15)",
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeNacimiento",
                table: "Teachers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Subjects",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(15)",
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Seccion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDeTelefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TutorLegal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiante_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    PrimerParcial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => new { x.IdEstudiante, x.IdMateria });
                    table.ForeignKey(
                        name: "FK_Notas_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Subjects_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_IdCurso",
                table: "Estudiante",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdMateria",
                table: "Notas",
                column: "IdMateria");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Curso_CursoId",
                table: "Subjects",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_MateriaId",
                table: "Teachers",
                column: "MateriaId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Curso_CursoId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_MateriaId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Teachers",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Teachers",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "NumeroDeTelefono",
                table: "Teachers",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "MateriaId",
                table: "Teachers",
                newName: "id_materia");

            migrationBuilder.RenameColumn(
                name: "FechaDeNacimiento",
                table: "Teachers",
                newName: "fecha_nacimiento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "id_profesor");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Subjects",
                newName: "nombre_corto");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Subjects",
                newName: "id_curso");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "id_materia");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_CursoId",
                table: "Subjects",
                newName: "IX_Subjects_id_curso");

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "Teachers",
                type: "nchar(15)",
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_nacimiento",
                table: "Teachers",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre_corto",
                table: "Subjects",
                type: "nchar(15)",
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    tutor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Grades_id_materia",
                table: "Grades",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_Students_id_curso",
                table: "Students",
                column: "id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Cursos",
                table: "Subjects",
                column: "id_curso",
                principalTable: "Courses",
                principalColumn: "id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Materias",
                table: "Teachers",
                column: "id_materia",
                principalTable: "Subjects",
                principalColumn: "id_materia");
        }
    }
}
