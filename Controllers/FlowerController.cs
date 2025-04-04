using FlowerInventory.Models;
using FlowerInventory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowerInventory.Controllers
{
    public class FlowerController : Controller
    {
        private readonly IFlowerService _flowerService;
        private readonly ICategoryService _categoryService;

        public FlowerController(IFlowerService flowerService, ICategoryService categoryService)
        {
            _flowerService = flowerService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var flowers = _flowerService.GetAllFlowers();
            return View(flowers);
        }

        public IActionResult Details(int id)
        {
            var flower = _flowerService.GetFlowerById(id);
            if (flower == null)
                return NotFound();

            return View(flower);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flower flower)
        {
            Console.WriteLine("Create POST method is being hit");
            if (ModelState.IsValid)
            {
                Debug.WriteLine($"Model is valid: {flower.Name}");
                _flowerService.AddFlower(flower);
                return RedirectToAction(nameof(Index));
            }

            Console.WriteLine("Model is invalid");
            Debug.WriteLine("ModelState is invalid");
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(flower);
        }


        public IActionResult Edit(int id)
        {
            var flower = _flowerService.GetFlowerById(id);
            if (flower == null)
                return NotFound(); 

            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(flower); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flower flower)
        {
            if (ModelState.IsValid)
            {
                _flowerService.UpdateFlower(flower);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(flower);
        }

        public IActionResult Delete(int id)
        {
            var flower = _flowerService.GetFlowerById(id);
            if (flower == null)
                return NotFound();

            return View(flower);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _flowerService.DeleteFlower(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
