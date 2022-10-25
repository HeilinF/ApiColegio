using ApiColegio.Context;
using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Dtos.SubjectDtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Queries.StudentQueries
{
    public class StudentQuery
    {
        private readonly ConexionSQLServer context;

        public StudentQuery(ConexionSQLServer context)
        {
            this.context = context;
        }
        public IQueryable<StudentToListDto> ToListbyId(int id)
        {
            var Query= context.Students
            .Select(student => new StudentToListDto
            {
                Id = student.IdStudent,
                Name = student.FirstName + " " + student.LastName,
                Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                PhoneNumber = student.PhoneNumber,
                Course = student.Course.Name + " " + student.Course.Section,

                Subjects = student.Course.Subjects.Select(subject => new SubjectToListDto
                {
                    Id = subject.IdSubject,
                    Name = subject.Name,

                    Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName

                })

            }).Where(x => x.Id == id)
            .AsQueryable();
            return Query;
        }
        

    }
}
