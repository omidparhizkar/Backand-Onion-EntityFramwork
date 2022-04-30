using System.Collections.Generic;

namespace CourseStore.Core.Domin
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseTeacher> CourseTeachers { get; set; }
    }
}