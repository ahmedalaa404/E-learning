using System.ComponentModel.DataAnnotations;

namespace E_Learning.Core.DataTransferObjects
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
