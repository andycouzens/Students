using Students.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public class EnrolmentRepo : IEnrolmentRepo
    {
        //TODO - Replace this with DI / Constructor
        StudentsDbContext _context = new StudentsDbContext();

        public Task<List<Enrolment>> GetEnrolmentsAsync(int studentId)
        {
            return _context.Enrolments.Where(x => x.Student.Id == studentId).ToListAsync();
        }
    }
}
