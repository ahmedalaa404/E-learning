using Microsoft.AspNetCore.Http;

namespace E_Learning.Core.DataTransferObjects
{
    public class InstructorDto
    {
        public string? Id { get; set; }

        public string? Fname { get; set; }
        public string? Lname { get; set; }


        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Linkedin { get; set; }
        public string? JobTitle { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }


        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
