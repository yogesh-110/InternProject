using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
     IUserRepository User { get; }
     ICategoryRepository Category { get; }
    ITaskRepository Task { get; }
        void Save();
    }
}
