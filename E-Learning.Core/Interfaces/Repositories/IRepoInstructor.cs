using E_Learning.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.Core.Interfaces.Repositories
{
    public interface IRepoInstructor
    {

        public AppUser GetById(string id);
    }
}
