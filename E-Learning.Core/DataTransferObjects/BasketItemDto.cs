using System.ComponentModel.DataAnnotations;

namespace E_Learning.Core.DataTransferObjects
{
    public class BasketItemDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]

        public string CourseName { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]
        [Range(1, 10)]
        public decimal Rating { get; set; }

        [Required]

        public string PictureUrl { get; set; }


        public string Category { get; set; }


        public int Lessons { get; set; }
    }
}
