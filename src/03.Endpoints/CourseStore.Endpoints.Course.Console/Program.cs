using System;
using System.Collections.Generic;
using CourseStore.Core.Domin;
using CourseStore.Infra.Data.Sql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseStore.Endpoints.CourseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryReadRepository.EagerLoadingSample01();
            Console.WriteLine("Press any key ....");
            Console.Read();
        }

      
    }
}
