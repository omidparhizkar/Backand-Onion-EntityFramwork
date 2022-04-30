using System;

namespace CourseStore.Core.Domin
{
    public class Comment
    {
        public int Id  { get; set; }
        public string Title  { get; set; }
        public string CommentText  { get; set; }
        public DateTime CommentDate  { get; set; }
    }
}