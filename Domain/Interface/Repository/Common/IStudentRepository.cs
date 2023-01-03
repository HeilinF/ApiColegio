using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Common;
public interface IStudentRepository : IRepositoryAsync<Student>
{
    Task<Student> GetByIdAndInclude(int id);
}

