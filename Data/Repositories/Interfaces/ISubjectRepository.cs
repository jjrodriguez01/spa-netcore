using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interrapidisimo.Models;

namespace interrapidisimo.Data.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<Subject?> GetByIdAsync(int id);
        Task<List<Subject>> GetAllAsync();
        Task<List<Subject>> GetByStudentAsync(string UserId);
        Task Enroll(string userId, int subjectId);
    }
}