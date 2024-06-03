using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace E_Learning.Core.DataTransferObjects
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        [ValidateNever]
        public IEnumerable<string> Roles { get; set; }
    }
}
