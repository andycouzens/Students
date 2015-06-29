using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Shell
{
    public interface IEnrolmentRepo
    {
        Task<List<Enrolment>> GetEnrolmentsAsync(int studentId);
    }
}
