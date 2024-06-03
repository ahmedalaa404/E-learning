using System.ComponentModel.DataAnnotations;

namespace E_Learning.Core.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Course>? Course { get; set; }
    }
}
