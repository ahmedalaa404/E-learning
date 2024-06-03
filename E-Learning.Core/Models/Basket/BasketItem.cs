namespace E_Learning.Core.Models.Basket
{
    public class BasketItem
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string PictureUrl { get; set; }
        public string Category { get; set; }
        public int Lessons { get; set; }

    }
}
