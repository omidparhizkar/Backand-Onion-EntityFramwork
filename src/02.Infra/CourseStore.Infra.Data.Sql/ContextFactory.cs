using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Data.Sql
{
    public static class ContextFactory
    {

        public static CourseDbContext GetSqlContext()
        {
            var builder =new DbContextOptionsBuilder<CourseDbContext>();
            builder.UseSqlServer("Data Source=.; Initial Catalog=CourseStore2; integrated security=true;");
            return new CourseDbContext(builder.Options);
        }


    }
}