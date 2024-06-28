using CrudOperationsDotNet8.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationsDotNet8.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories =  CategoryRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
        var category= CategoryRepository.GetCategoryById(id.HasValue?id.Value:0);
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
				CategoryRepository.UpdateCategory(category.CategoryId, category);
				return RedirectToAction("Index");
			}
            return View(category);
		
		}

        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoryRepository.AddCategory(category);
                return RedirectToAction("Index");
            } 
            return View(category);
        }

        public IActionResult Delete(int id) { 
        
            CategoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
