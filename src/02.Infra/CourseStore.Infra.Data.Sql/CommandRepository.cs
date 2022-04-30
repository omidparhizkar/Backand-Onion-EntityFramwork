using System;
using System.Linq;
using CourseStore.Core.Domin;

namespace CourseStore.Infra.Data.Sql
{
    public class CommandRepository
    {
        public void CheckEntityState()
        {
            var ctx = ContextFactory.GetSqlContext();
            var teacher=new Teacher
            {
                FirstName = "Masoud",
                LastName = "Taheri"
            };
            ctx.Add(teacher);
            Console.WriteLine($" Teacher State Is : {ctx.Entry(teacher).State}");
            var course = ctx.Courses.FirstOrDefault();
            Console.WriteLine($"Course State Before Change Is : {course}");
            course.Title = "Pro Ef and ASP.NET Core ";
            Console.WriteLine($" Teacher State Is : {ctx.Entry(teacher).State}");
        }   
    }
}