using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class Enrolment
    {
        [Key]
        public int Id { get; set; }

        public string CourseName { get; set; }
        public bool Active { get; set; }
        public virtual Student Student { get; set; }
    }
}
