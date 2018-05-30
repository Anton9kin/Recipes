using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipesApp.Models;

namespace RecipesApp.Controllers
{
    public class HomeController : Controller
    {
        RecipeContext db = new RecipeContext();
        string[] TypeCourse = new string[] { "Супы", "Вторые блюда", "Салаты",  "Закуски", "Выпечка", "Десерты", "Напитки"};

        private string TypeCourseGetMenu(string type)
        {
            string s = "";

            switch (type)
            {
                case "Soup":         s = "Супы"; break;
                case "SecondCourse": s = "Вторые блюда"; break;
                case "Salad":        s = "Салаты"; break;
                case "Snak":         s = "Закуски"; break;
                case "Bake":         s = "Выпечка"; break;
                case "Dessert":      s = "Десерты"; break;
                case "Drink":        s = "Напитки"; break;
            }

            return s;
        }

        private string TypeCourseGetType(string menu)
        {
            string s = "";

            switch (menu)
            {
                case "Супы": s = "Soup"; break;
                case "Вторые блюда": s = "SecondCourse"; break;
                case "Салаты": s = "Salad"; break;
                case "Закуски": s = "Snak"; break;
                case "Выпечка": s = "Bake"; break;
                case "Десерты": s = "Dessert"; break;
                case "Напитки": s = "Drink"; break;
            }

            return s;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id)
        {
            var recipes = db.Recipes;
            List<Recipe> list = new List<Recipe>();

            if (id == null)
                id = "Soup";

            id = TypeCourseGetMenu(id);

            foreach(Recipe rec in recipes)
            {
                if (rec.Type == id)
                {
                    list.Add(rec);
                }
            }
            ViewBag.Cat = id;
            ViewBag.Recipes = list;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(Recipe rec)
        {
            string s = "";

            db.Recipes.Add(rec);

            db.SaveChanges();

            s = "~/Home/About/" + rec.Id.ToString();

            Response.Redirect(s);

            return s;
        }

        public ActionResult About(string id)
        {
            Recipe recipe;
            int idRec;

            if (id != null)
            {
                idRec = Int32.Parse(id);
                recipe = db.Recipes.Find(idRec);
                if (recipe != null)
                {
                    return View(recipe);
                }
                else
                {
                    return View("~/Views/Home/NotFound.cshtml");
                }
            }
            else
            {
                return View("~/Views/Home/NotFound.cshtml");
            }
        }
        [HttpGet]
        public ActionResult Editor(string id)
        {
            Recipe recipe;
            int idRec;

            if (id != null)
            {
                idRec = Int32.Parse(id);
                recipe = db.Recipes.Find(idRec);
                if (recipe != null)
                {

                    return View(recipe);
                }
                else
                {
                    return View("~/Views/Home/NotFound.cshtml");
                }
            }
            else
            {
                return View("~/Views/Home/NotFound.cshtml");
            }
        }

        [HttpPost]
        public void Editor(Recipe rec)
        {
            db.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            string s = "~/Home/About/" + rec.Id.ToString();

            Response.Redirect(s);
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}