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
    public class TaskRepository : Repository<Intern.Models.Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Intern.Models.Task obj)
        {
            var objfromDb = _context.Tasks.FirstOrDefault(u => u.TaskID == obj.TaskID);
            objfromDb.Title = obj.Title;
            objfromDb.Description = obj.Description;
            objfromDb.DueDate = obj.DueDate;
            objfromDb.IsCompleted = obj.IsCompleted;
            objfromDb.UserId = obj.UserId;
            objfromDb.CategoryId = obj.CategoryId;

     
            _context.Tasks.Update(obj);
        }

        
    }
}
