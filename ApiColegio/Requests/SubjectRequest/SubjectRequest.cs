using ApiColegio.Context;
using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Requests.SubjectRequest
{
    public class SubjectRequest
    {
        private readonly ConexionSQLServer context;
        public SubjectRequest(ConexionSQLServer context)
        {
            this.context = context;
        }

        public IQueryable<SubjectToListDto> ToList()
        {
            var Query = context.Subjects.Select(subject => new SubjectToListDto
            {
                Id = subject.IdSubject,
                Name = subject.Name,
                Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName,
            }).AsQueryable();
            return Query;
            
        }

        public IQueryable<SubjectToListDto> ToListById(int id)
        {
            var Query = context.Subjects.Select(subject => new SubjectToListDto
            {
                Id = subject.IdSubject,
                Name = subject.Name,
                Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName,
            }).Where(x => x.Id == id)
            .AsQueryable();
            return Query;
        }

        public void Create(SubjectRegisterDto subject)
        {
            var subjectRegistered = new Subject
            {
                Name = subject.Name,
                // Level = materia.Level,
                IdCourse = subject.IdCourse
            };
            context.Subjects.Add(subjectRegistered);
            context.SaveChanges();
           

        }

        public void Update(SubjectUpdateDto subject)
        {

            var subjectUpdated = new Subject
            {
                IdSubject = subject.Id,
                Name = subject.Name,
                // Level = subject.Level,
                IdCourse = subject.IdCourse
            };
            context.Subjects.Update(subjectUpdated).State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var subject = context.Subjects.Find(id);
            if (subject != null)
            {
                context.Remove(subject);
                context.SaveChanges();
               
            }

        }

        public bool Exist(int id)
        {
            return context.Subjects.Any(x => x.IdSubject == id);
        }
    }
}
