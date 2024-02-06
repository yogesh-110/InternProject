using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern.DataAccess.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Intern.Models.Task>
    {
        void Update(Intern.Models.Task obj);
        
    }
}
