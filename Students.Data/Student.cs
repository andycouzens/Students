using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class Student
    {
        public Student()
        {
            Enrolments = new List<Enrolment>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public virtual List<Enrolment> Enrolments { get; set; }
    }
}
