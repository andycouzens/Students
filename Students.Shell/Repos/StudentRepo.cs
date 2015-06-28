using Students.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public class StudentRepo : IStudentRepo
    {
        //TODO - Replace this with DI / Constructor
        StudentsDbContext _context = new StudentsDbContext();

        public Task<List<Student>> GetStudentsAsync()
        {
            return _context.Students.ToListAsync();
        }

        public Task<Student> GetStudentAsync(int id)
        {
            return _context.Students.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Student> AddStudentAsync(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> UpdateStudentAsync(Student Student)
        {
            if (!_context.Students.Local.Any(c => c.Id == Student.Id))
            {
                _context.Students.Attach(Student);
            }
            _context.Entry(Student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Student;

        }

        public async Task DeleteStudentAsync(int StudentId)
        {
            var Student = _context.Students.FirstOrDefault(c => c.Id == StudentId);
            if (Student != null)
            {
                _context.Students.Remove(Student);
            }
            await _context.SaveChangesAsync();
        }
    }
}
