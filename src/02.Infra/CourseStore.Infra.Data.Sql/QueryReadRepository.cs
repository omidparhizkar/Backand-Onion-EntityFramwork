using CourseStore.Core.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Data.Sql
{
    public static class QueryReadRepository
    {
        public static void AddDefaultData()
        {
            var context = ContextFactory.GetSqlContext();

            //context.Courses.Where(Coursese => Coursese.Title == "").AsNoTracking();
            context.Courses.Where(Coursese => Coursese.Title == "");


            context.Courses.Add(new Course
            {
                Title = "ASP.Net Core",
                Price = 100,
                Description = "Description net Core",
                Discount = new Discount
                {
                    Name = "Yalda",
                    NewPrice = 80
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Title = "Comment Title",
                        CommentDate = DateTime.Now,
                        CommentText = "Comment Text"
                    },

                },
                CourseTeachers = new List<CourseTeacher>
                {
                    new CourseTeacher
                    {
                        ShortOrder = 1,
                        Teacher = new Teacher
                        {
                            FirstName = "Alireza ",
                            LastName = "Oroumand",

                        }
                    }
                },
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Title = "Asp.Net"
                    },
                    new Tag
                    {
                        Title = ".NET 5"
                    }
                }

            });


            context.SaveChanges();


        }

        public static void EagerLoadingSample01()
        {
            var ctx = ContextFactory.GetSqlContext();
            var query = ctx.Courses.
                Include(c => c.Discount).
                Include(c => c.Comments.Where(c=>c.CommentDate>= DateTime.Now.AddDays(-10))).
                Include(c => c.CourseTeachers).
                ThenInclude(d => d.Teacher).
                Include(c => c.Tags);

            var queryString = query.ToQueryString();
            var result = query.ToList();
        }

        public static void ExplicitLoading()
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Courses.FirstOrDefault();
            ctx.Entry(course).
                Reference(c=>c.Discount).Load();
        }

        public static void SelectSqlContext()
        {
            var ctx = ContextFactory.GetSqlContext();
            var course = ctx.Courses.Select(c=>new
            {
                Title =c.Title,
                Price = c.Price,
                NewPrice =c.Price,
                PriceTitle=c.Comments.Count()
            });
        }

    }
}