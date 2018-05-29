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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id)
        {
            var recipes = db.Recipes;

            ViewBag.Recipes = recipes;

            if (id != null)
                ViewBag.Cat = id;
            else
                ViewBag.Cat = "Soup";

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
            
            s += "Вы успешно создали рецепт: ";
            s += rec.Name + " в категории " + rec.Type + " ";
            s += "Ингридиенты: " + rec.Ingridient + " ";
            s += "Спосбо приготовления: " + rec.Cooking;
            s += "Фото: " + rec.Image;

            rec.Type = GetTypeCourse(rec.Type);

            db.Recipes.Add(rec);

            db.SaveChanges();

            s = "~/Home/About/" + rec.Id.ToString();

            Response.Redirect(s);

            return s;
        }

        private string GetTypeCourse(string type)
        {
            string s = "";

            switch (type)
            {
                case "Суп":             s = "Soup"; break;
                case "Второе блюдо":    s = "SecondCourse"; break;
                case "Салат":           s = "Salad"; break;
                case "Закуска":         s = "Snak"; break;
                case "Выпечка":         s = "Bake"; break;
                case "Десерт":          s = "Dessert"; break;
                case "Напиток":         s = "Drink"; break;
                default:                s = "Soup"; break;
            }

            return s;

        }

        public ActionResult About(string id)
        {
            var recipes = db.Recipes;
            int idRec;

            if (id != null)
            {
                idRec = Int32.Parse(id);
            }
            else
            {
                idRec = 0;
            }

            foreach(Recipe r in db.Recipes)
            {
                if (r.Id == idRec)
                {
                    ViewBag.Recipe = r;
                    return View();
                }
            }

            Recipe rec = new Recipe();
            rec.Id = 0;
            ViewBag.Recipe = rec;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}