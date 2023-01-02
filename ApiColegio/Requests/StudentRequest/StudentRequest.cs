using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Dtos.SubjectDtos;
using AutoMapper;
using Domain.Context;
using Domain.Entities.Models;
using Domain.Interface.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Requests.StudentRequest
{
    public class StudentRequest
    {
        private readonly ConexionSQLServer context;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentRequest(ConexionSQLServer context, IMapper mapper, IStudentRepository studentRepository)
        {
            this.context = context;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<StudentToListDto> ToListbyId(int id)
        {
            //if(!StudentExist(id)) {}
            //var Query = context.Students
            //.Select(student => new StudentToListDto
            //{
            //    Id = student.IdStudent,
            //    Name = student.FirstName + " " + student.LastName,
            //    Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
            //    PhoneNumber = student.PhoneNumber,
            //    Course = student.Course.Name + " " + student.Course.Section,

            //    Subjects = student.Course.Subjects.Select(subject => new SubjectToListDto
            //    {
            //        Id = subject.IdSubject,
            //        Name = subject.Name,

            //        Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName

            //    })

            //}).Where(x => x.Id == id)
            //.AsQueryable();

            var Query = await _studentRepository.GetByIdAync(id);

            var studentMapped =  _mapper.Map<StudentToListDto>(Query);
            return studentMapped;
        }
     
        public IQueryable<StudentToListDto> ToList()
        {
            var Query = context.Students
               .Select(student => new StudentToListDto
               {
                   Id = student.Id,
                   Name = student.FirstName + " " + student.LastName,
                   Age = (short)Math.Floor((DateTime.Now - student.Date).TotalDays / 365),
                   PhoneNumber = student.PhoneNumber,
                   Course = student.Course.Name + " " + student.Course.Section,

                   Subjects = student.Course.Subjects.Select(subject => new SubjectToListDto
                   {
                       Id = subject.Id,
                       Name = subject.Name,

                       Teacher = subject.Teacher.FirstName + " " + subject.Teacher.LastName

                   })

               }).AsQueryable();
            return Query;

        }

        public void Register(StudentRegisterDto student)
        {
            var studentRegistered = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Date = student.Date,
                PhoneNumber = student.PhoneNumber,
                Tutor = student.Tutor,
                IdCourse = student.IdCourse,
            };

            context.Students.Add(studentRegistered);
            context.SaveChanges();

        }

        public void Update(StudentUpdateDto student)
        {

            var studentUpdated = new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Date = student.Date,
                PhoneNumber = student.PhoneNumber,
                Tutor = student.Tutor,
                IdCourse = student.IdCourse,
            };

            context.Update(studentUpdated).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            };

        }

        public void Delete(int id)
        {
            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Remove(student);
                context.SaveChanges();
                
            }
               
        }

        public bool Exist(int id)
        { 
            return context.Students.Any(x => x.Id == id); 
        }
    }
}
