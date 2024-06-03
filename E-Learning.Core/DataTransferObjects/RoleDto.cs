using System.ComponentModel;

namespace E_Learning.Core.DataTransferObjects
{
    public class RoleDto
    {
        public string Id { get; set; }
        [DisplayName("Role")]
        public string Name { get; set; }

        public RoleDto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
