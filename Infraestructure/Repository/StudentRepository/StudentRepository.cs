using Domain.Context;
using Domain.Entities.Models;
using Domain.Interface.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.StudentRepository
{
    public class StudentRepository : RepositoryAsync<Student>, IStudentRepository
    {
        public StudentRepository(ConexionSQLServer context) : base(context)
        {
        }
    }
}
