using E_Learning.Core.Models;
using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repository.Data
{
    public class LearningDbContext : IdentityDbContext<AppUser>
    {
        public LearningDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("users");


            // Configure the index
            builder.Entity<StudentCourses>()
                .HasKey(p => new { p.AppUserId, p.CourseId });


            builder.Entity<StudentCourses>()
                .HasOne(sc => sc.AppUser)
                .WithMany(u => u.AppUserCourse)
                .HasForeignKey(sc => sc.AppUserId)
                .OnDelete(DeleteBehavior.Restrict); // Or


            builder.Entity<Course>().HasOne(x => x.Instructor).WithMany(x => x.InstructorsCourses).HasForeignKey(x => x.InstructorId);

            #region Seeding Roles

            IEnumerable<IdentityRole> roles = new List<IdentityRole>()
            {
                 new IdentityRole()
                {
                    Name = "Admin"
                },
                 new IdentityRole()
                {
                    Name = "Instructor"
                },
                 new IdentityRole()
                {
                    Name = "Student"
                 }

            };

            #endregion
            builder.Entity<IdentityRole>().HasData(roles);
        }



        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AppUser> appusers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        

    }
}
