using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning.Core.Models
{
    public class AppUser : IdentityUser
    {
        public bool Agree { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }


        #region Instrucotr
        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Linkedin { get; set; }
        public string? JobTitle { get; set; }

        public string? ImageName { get; set; }

        #endregion


        #region Student

        public DateTime? BirthDate { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        //public ICollection<Course>? Coursestaughtbythestudent { get; set; }


        public ICollection<Course>? InstructorsCourses { get; set; }

        public ICollection<StudentCourses>? AppUserCourse { get; set; }

        #endregion
    }
}
