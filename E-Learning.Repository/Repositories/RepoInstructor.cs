using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models;
using E_Learning.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.Repository.Repositories
{
    public class RepoInstructor:IRepoInstructor
    {
        private readonly LearningDbContext dbcontext;

        public RepoInstructor(LearningDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public AppUser GetById(string id)
        {
            return dbcontext.appusers.FirstOrDefault(x=>x.Id==id);
        }

    }
}
