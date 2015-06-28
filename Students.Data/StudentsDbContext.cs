using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext()
        {
        }

        public DbSet<Student> Students
        {
            get;
            set;
        }

        public DbSet<Enrolment> Enrolments
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
