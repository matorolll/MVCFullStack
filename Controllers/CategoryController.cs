﻿using Microsoft.AspNetCore.Mvc;

namespace MVCFullStack.Controllers
{
	public class CategoryController : Controller
	{
		private readonly Context _db;
		public CategoryController(Context db)
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
		public IActionResult Create(Category obj) {
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "DisplayOrder cannot exactly match the name");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
			return View();
		}


		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			//Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();


			if(categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}


		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}
			return View();
		}




		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}

	}
}
