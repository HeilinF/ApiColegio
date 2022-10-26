using ApiColegio.Context;
using ApiColegio.Dtos.TeacherDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Requests.TeacherRequest
{
    public class TeacherRequest
    {
        private readonly ConexionSQLServer context;

        public TeacherRequest(ConexionSQLServer context)
        {
            this.context = context;
        }

        public IQueryable<TeacherToListDto> ToList()
        {
            var Query = context.Teachers
                .Select(teacher => new TeacherToListDto
                {
                    Id = teacher.IdTeacher,
                    Name = teacher.FirstName + " " + teacher.LastName,
                    PhoneNumber = teacher.PhoneNumber,

                    Subject = teacher.Subject.Name
                }).AsQueryable();
            return Query;
        }

        public IQueryable<TeacherToListDto> ToListById(int id)
        {

            var Query = context.Teachers.Select(
                teacher => new TeacherToListDto
                {
                    Id = teacher.IdTeacher,
                    Name = teacher.FirstName + " " + teacher.LastName,
                    PhoneNumber = teacher.PhoneNumber,

                    Subject = teacher.Subject.Name

                }).Where(x => x.Id == id)
                .AsQueryable();


            return Query;

        }

        public void Update(TeacherUpdateDto teacher)
        {
            var teacherUpdated = new Teacher
            {
                IdTeacher = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PhoneNumber = teacher.PhoneNumber,
                IdSubject = teacher.IdSubject,
            };
                context.Update(teacherUpdated).State = EntityState.Modified;
                context.SaveChanges();

        }

        public void Register(TeacherRegisterDto teacher)
        {
            var teacherRegistered = new Teacher
                {
                    // IdProfesor = profesor.IdProfesor,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Date = teacher.Date,
                    PhoneNumber = teacher.PhoneNumber,
                    IdSubject = teacher.IdSubject
            };

                context.Teachers.Add(teacherRegistered);
                context.SaveChanges();
          
            
        }

        public void Remove(int id)
        {
            var teacher = context.Teachers.Find(id);

            if (teacher != null)
                try
                {
                    context.Teachers.Remove(teacher);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public bool Exists(int id)
        {
            return context.Teachers.Any(e => e.IdTeacher == id);
        }
    }
}
