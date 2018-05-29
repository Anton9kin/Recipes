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
        Dictionary<TypeCourse, string> typeCourse = new Dictionary<TypeCourse, string>()
        {
            { TypeCourse.Soup,          "Супы"},
            { TypeCourse.SecondCourse,  "Вторые блюда"},
            { TypeCourse.Salad,         "Салаты"},
            { TypeCourse.Snak,          "Закуска"},
            { TypeCourse.Bake,          "Выпечка"},
            { TypeCourse.Dessert,       "Десерт"},
            { TypeCourse.Drink,         "Напитки"}
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id)
        {
            var recipes = db.Recipes;
            List<Recipe> list = new List<Recipe>();
            TypeCourse type;

            if (id == null)
                id = TypeCourse.Soup.ToString();

            type = (TypeCourse)Enum.Parse(typeof(TypeCourse), id);

            foreach(Recipe rec in recipes)
            {
                if (rec.Type.Equals(type))
                {
                    list.Add(rec);
                }
            }

            ViewBag.Cat = typeCourse[type];
            ViewBag.Recipes = list;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<TypeCourse, string> type in typeCourse)
            {
                list.Add(type.Value);
            }

            ViewBag.List = list;
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
                    recipe = new Recipe() { Id = 0 };
                    return View(recipe);
                }
            }
            else
            {
                recipe = new Recipe() { Id = 0 };
                return View(recipe);
            }
        }

        public ActionResult Editor(string id)
        {
            Recipe recipe;
            int idRec;

            List<string> list = new List<string>();
            foreach (KeyValuePair<TypeCourse, string> type in typeCourse)
            {
                list.Add(type.Value);
            }

            ViewBag.List = list;
            ViewBag.Type = typeCourse;

            if (id != null)
            {
                idRec = Int32.Parse(id);
                recipe = db.Recipes.Find(idRec);
                if (recipe != null)
                {
                    ViewBag.SelType = typeCourse[recipe.Type];
                    return View(recipe);
                }
                else
                {
                    recipe = new Recipe() { Id = 0 };
                    return View(recipe);
                }
            }
            else
            {
                recipe = new Recipe() { Id = 0 };
                return View(recipe);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}