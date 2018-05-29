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

            ViewBag.Cat = id;
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

            switch (rec.Type)
            {
                case "Суп": rec.Type = "Soup"; break;
                case "Второе блюдо": rec.Type = "SecondCourse"; break;
                case "Салат": rec.Type = "Salad"; break;
                case "Закуска": rec.Type = "Snak"; break;
                case "Выпечка": rec.Type = "Bake"; break;
                case "Десерт": rec.Type = "Dessert"; break;
                case "Напиток": rec.Type = "Drink"; break;
            }

            db.Recipes.Add(rec);

            db.SaveChanges();

            s = "~/Home/About/" + rec.Id.ToString();

            Response.Redirect(s);

            return s;
        }

        public ActionResult About(string id)
        {
            var recipes = db.Recipes;

            ViewBag.Recipes = recipes;

            if (id != null)
            {
                ViewBag.Show = UInt32.Parse(id);
            }
            else
            {
                ViewBag.Show = 0;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}