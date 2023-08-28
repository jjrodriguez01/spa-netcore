using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interrapidisimo.Data.Repositories.Interfaces;
using interrapidisimo.Models;
using Microsoft.EntityFrameworkCore;

namespace interrapidisimo.Data.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Subject>> GetAllAsync()
        {
            return _context.Subjects.Include(s => s.Teacher).ToListAsync();
        }

        public Task<List<Subject>> GetByStudentAsync(string UserId)
        {
            return _context.Subjects
            .Include(s => s.Teacher)
            .Where(s => s.UserSubjects.Any(s => s.UserId == UserId))
            .ToListAsync();
        }

        public async Task Enroll(string userId, int subjectId)
        {
            var userSubject = new UserSubject();
            userSubject.UserId = userId;
            userSubject.SubjectId = subjectId;
            _context.UserSubjects.Add(userSubject);
            await _context.SaveChangesAsync();
        }

        public Task<Subject?> GetByIdAsync(int id)
        {
            return _context.Subjects
            .Include(s =>s.Teacher)
            .Include(s => s.UserSubjects)
            .ThenInclude(s => s.User)
            .Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}