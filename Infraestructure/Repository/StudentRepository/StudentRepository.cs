using Domain.Context;
using Domain.Entities.Models;
using Domain.Interface.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.StudentRepository
{
    public class StudentRepository : RepositoryAsync<Student>, IStudentRepository
    {
        private readonly ConexionSQLServer _context;
        public StudentRepository(ConexionSQLServer context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAndInclude(int id)
            =>
        
            await _context.Students.Where(x=>x.Id==id).Include(x=>x.Course).FirstOrDefaultAsync();
            
        
    }
}
