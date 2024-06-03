namespace E_Learning.Core.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
