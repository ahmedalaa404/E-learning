using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Repository.Data;

namespace E_Learning.Repository.Repositories
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(LearningDbContext context) : base(context)
        {
        }
    }
}
