using Intern.DataAccess.Data;
using Intern.DataAccess.Repository.IRepository;
using Intern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(User obj)
        {
            _context.Users.Update(obj);
        }
    }
}
