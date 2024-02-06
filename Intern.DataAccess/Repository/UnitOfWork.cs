
using Intern.DataAccess.Data;
using Intern.DataAccess.Repository.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
           _context = context;
            User = new UserRepository(_context);
            Category = new CategoryRepositoy(_context);
            Task = new TaskRepository(_context);
        }
        public IUserRepository User { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ITaskRepository Task { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
