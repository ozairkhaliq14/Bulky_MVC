using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Numerics;


namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            TempData["success"] = "Product Created Successfully.";
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
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
            Product? productById = _unitOfWork.Product.Get(u => u.Id == id);

            if (productById == null)
            {
                return NotFound();
            }
            return View(productById);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            
            TempData["success"] = "Product Edited Successfully.";

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
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
            Product? productById = _unitOfWork.Product.Get(u => u.Id == id);

            if (productById == null)
            {
                return NotFound();
            }
            return View(productById);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? productById = _unitOfWork.Product.Get(u => u.Id == id);

            if (productById == null)
            {
                return NotFound();
            }
            TempData["success"] = "Product Deleted Successfully.";

            _unitOfWork.Product.Remove(productById);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Product");

        }
    }
}
