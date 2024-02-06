using Intern.DataAccess.Repository.IRepository;
using Intern.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InternProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<User> list  = _unitOfWork.User.GetAll();
            return View(list);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
         
                  var UserFromDb = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            
            if (UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)   
        {           
                _unitOfWork.User.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "User Updated Successfully";
                return RedirectToAction("Index");           
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var UserFromDb = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id== id);
            if (UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.User.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "User Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}
