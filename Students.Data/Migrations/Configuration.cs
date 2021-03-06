namespace Students.Data.Migrations
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Students.Data.StudentsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Students.Data.StudentsDbContext context)
        {
            context.Students.AddOrUpdate(
              p => new { p.FirstName, p.Surname },
              new Student
              {
                  FirstName = "Andrew",
                  Surname = "Peters",
                  Enrolments = new List<Enrolment>() { 
                      new Enrolment { Active = true, CourseName = "Software Dev Year Two" },
                      new Enrolment { Active = false, CourseName = "Software Dev One" }}
              },
              new Student { FirstName = "Brice", Surname = "Lambson" },
              new Student { FirstName = "Rowan", Surname = "Miller" }
            );
        }
    }
}
