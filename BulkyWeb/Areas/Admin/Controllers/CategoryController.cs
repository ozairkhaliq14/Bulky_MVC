using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot be the same as the Display Order");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The Name cannot be 'name'");
            }
            TempData["success"] = "Category Created Successfully.";

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        //Edit Method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryById = _unitOfWork.Category.Get(u => u.Id == id );

            if (categoryById == null)
            {
                return NotFound();
            }
            return View(categoryById);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name cannot be the same as the Display Order");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The Name cannot be 'name'");
            }
            TempData["success"] = "Category Edited Successfully.";

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        //Delete Method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryById = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryById == null)
            {
                return NotFound();
            }
            return View(categoryById);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? categoryById = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryById == null)
            {
                return NotFound();
            }
            TempData["success"] = "Category Deleted Successfully.";

            _unitOfWork.Category.Remove(categoryById);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Category");

        }
    }
}
