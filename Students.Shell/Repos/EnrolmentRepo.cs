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

        public Task<List<Enrolment>> GetEnrolmentsAsync()
        {
            return _context.Enrolments.ToListAsync();
        }
    }
}
