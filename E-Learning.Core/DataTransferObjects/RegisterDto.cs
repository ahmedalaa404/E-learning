using System.ComponentModel.DataAnnotations;

namespace E_Learning.Core.DataTransferObjects
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9!@#$%^&*()-_=+]{8,}$", ErrorMessage = "Password Must Contain 1 UpperCase , 1 LowerCase")]
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
