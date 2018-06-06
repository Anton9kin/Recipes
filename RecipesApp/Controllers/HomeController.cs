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

        public Dictionary<string, string> TypeDish = Helpers.Helper.MenuDish;

        Dictionary<string, string> SecondDish = Helpers.Helper.SecondMenuDish;

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

            if (TypeDish.ContainsKey(id))
            {
                id = TypeDish[id];
            }
            else
            {
                if (SecondDish.ContainsKey(id))
                {
                    id = SecondDish[id];
                }
            }
                

            foreach(Recipe rec in recipes)
            {
                if (rec.Type == id)
                {
                    list.Add(rec);
                }
            }
            ViewBag.Cat = id;
            ViewBag.Recipes = list;
            ViewBag.TypeDish = SecondDish;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<string> list = new List<string>();

            foreach(string type in TypeDish.Values)
            {
                list.Add(type);
                if (type == "Вторые блюда")
                {
                    foreach(string subtype in SecondDish.Values)
                    {
                        list.Add(subtype);
                    }
                }
            }

            ViewBag.SelectList = list.ToArray();

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
                    List<string> list = new List<string>();

                    foreach (string type in TypeDish.Values)
                    {
                        list.Add(type);
                        if (type == "Вторые блюда")
                        {
                            foreach (string subtype in SecondDish.Values)
                            {
                                list.Add(subtype);
                            }
                        }
                    }

                    ViewBag.SelectList = list.ToArray();
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