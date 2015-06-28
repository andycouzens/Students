using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
