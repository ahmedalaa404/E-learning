using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OverView { get; set; }
        public double Duration { get; set; }
        public int Lessons { get; set; }
        public double Videos { get; set; }
        public string Language { get; set; }

        public double Price { get; set; }
        public ICollection<StudentCourses> studentCourses { get; set; }


        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public AppUser Instructor { get; set; }

        public ICollection<Assignment> Assignment { get; set; }
        public Topic Topics { get; set; }
        public int TopicId { get; set; }
    }
}
