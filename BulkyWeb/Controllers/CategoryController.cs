using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); 
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

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
				return RedirectToAction("Index", "Category");
			}
            return View();
		}

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryById = _db.Categories.Find(id);

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

			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
	}
}
