using Intern.DataAccess.Repository.IRepository;
using Intern.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace InternProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? Id)
        {
            TaskVM taskVM = new()
            {
                Task = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(
                i => new SelectListItem
                {
                    Text =i.Name,
                    Value = i.Id.ToString()
                }
                ),

                UserList = _unitOfWork.User.GetAll().Select(
               i => new SelectListItem
               {
                   Text = i.UserName,
                   Value = i.UserId.ToString()
               }
               ),
            };

            if (Id == null || Id == 0)
            {
                //create product
                //ViewBag.CategoryList = CategoryList; //viewbag procress
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(taskVM);
            }
            else
            {
                taskVM.Task = _unitOfWork.Task.GetFirstOrDefault(u => u.TaskID == Id);
                return View(taskVM);
                //update product
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TaskVM obj)
        {

              if (obj.Task.TaskID == 0)
                {
                    _unitOfWork.Task.Add(obj.Task);
                }
                else
                {
                    _unitOfWork.Task.Update(obj.Task);
                }
            
           

            _unitOfWork.Save();
            TempData["success"] = "Task Created Successfully";
            return RedirectToAction("Index");

        }


       

        #region API CALLS  
        [HttpGet]
        public IActionResult GetAll()
        {
            var CatList = _unitOfWork.Task.GetAll(includeProperties: "Category");
            var UseList = _unitOfWork.Task.GetAll(includeProperties: "User");
            return Json(new { data = CatList,UseList });
        }
        //post
        [HttpDelete]

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Task.GetFirstOrDefault(u => u.TaskID == id);
            
            _unitOfWork.Task.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }

}

   