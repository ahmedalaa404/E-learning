using System.ComponentModel.DataAnnotations;

namespace E_Learning.Core.DataTransferObjects
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
    }
}
