namespace E_Learning.Core.Models
{
    public class StudentCourses
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
