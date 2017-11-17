namespace LexiconUniversity.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconUniversity.DataAccess.LexiconUniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LexiconUniversity.DataAccess.LexiconUniversityContext";
        }

        protected override void Seed(DataAccess.LexiconUniversityContext context)
        {
            context.Courses.AddOrUpdate(
                c => c.CourseId,
                new Course { CourseId = "PP123", Credits = 5, Name = "PHP for Poets" },
                new Course { CourseId = "DN123", Credits = 7, Name = "DotNet for Accountants" },
                new Course { CourseId = "JE123", Credits = 9, Name = "Java for Coffedrinkers" }
            );

            Student[] students = new[] {
                new Student { FirstName = "Adam", LastName = "Andersson" },
                new Student { FirstName = "Berit", LastName = "Bosson" },
                new Student { FirstName = "Cesar", LastName = "Carlsson" },
                new Student { FirstName = "David", LastName = "Dre" }
            };
            context.Students.AddOrUpdate(s => new { s.FirstName, s.LastName }, students);
            context.SaveChanges();

            context.Enrollments.AddOrUpdate(
                e => new { e.CourseId, e.StudentId },
                new Enrollment { CourseId = "PP123", StudentId = students[0].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[1].Id },
                new Enrollment { CourseId = "PP123", StudentId = students[2].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[1].Id },
                new Enrollment { CourseId = "DN123", StudentId = students[2].Id },
                new Enrollment { CourseId = "JE123", StudentId = students[0].Id }
            );
        }
    }
}
