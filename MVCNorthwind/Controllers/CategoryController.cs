using MVCNotrhwindTekrar_1.DesignPatterns.SingletonPattern;
using MVCNotrhwindTekrar_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNotrhwindTekrar_1.Controllers
{
    //This project uses a database from a virtual company named Northwind (Database is integrated to the project with Database First), and is used for CRUD operations via MVC. Singleton pattern is used to make sure the database is only instanced once.


    public class CategoryController : Controller
    {
        
        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        public ActionResult ListCategories()
        {
            
            return View(_db.Categories.ToList());
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            return View(_db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category item)
        {
            Category guncellenecek = _db.Categories.Find(item.CategoryID);
            guncellenecek.CategoryName = item.CategoryName;
            guncellenecek.Description = item.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");

        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }
        
    }
}