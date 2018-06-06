using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesApp.Helpers
{
    public static class Helper
    {
        public static Dictionary<string, string> MenuDish { get; set; } = new Dictionary<string, string>
        {
            { "Soup",               "Супы" },
            { "SecondCourse",       "Вторые блюда"},
            { "Salad",              "Салаты" },
            { "Snak",               "Закуски" },
            { "Bake",               "Выпечка" },
            { "Dessert",            "Десерты" },
            { "Drink",              "Напитки" },
        };

        public static Dictionary<string, string> SecondMenuDish { get; set; } = new Dictionary<string, string>
        {
            { "SecondMeat",         "Второе из мяса" },
            { "SecondFish",         "Второе из рыбы" },
            { "SecondChicken",      "Второе из курицы" },
            { "SecondPotate",       "Второе из картофеля" },
            { "SecondKasha",        "Каши" }
        };

        private static string GetKey(Dictionary<string, string> dict, string value)
        {
            string[] keys = dict.Keys.ToArray();
            string[] val = dict.Values.ToArray();

            for(int i = 0; i < val.Length; i++)
            {
                if (value == val[i])
                {
                    return keys[i];
                }
            }

            return keys[0];
        }

        public static MvcHtmlString CreateMenu(this HtmlHelper html, string Category)
        {
            TagBuilder ul = new TagBuilder("ul");

            foreach(string menu in MenuDish.Values)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                TagBuilder b = new TagBuilder("b");

                b.SetInnerText(menu);

                a.InnerHtml += b.ToString();
                a.MergeAttribute("href", "/Home/Category/" + GetKey(MenuDish, menu));

                li.InnerHtml += a.ToString();
                if (menu.Equals(Category))
                {
                    li.AddCssClass("current");
                }
                else
                {
                    if (menu == MenuDish["SecondCourse"])
                    {
                        if (SecondMenuDish.Values.Contains(Category))
                        {
                            li.AddCssClass("current");
                        }
                    }
                }

                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }

        public static MvcHtmlString CreateList(this HtmlHelper html, string nameList, string list)
        {
            MvcHtmlString mvc;

            TagBuilder h = new TagBuilder("h2");
            h.SetInnerText(nameList);

            mvc = new MvcHtmlString(h.ToString() + CreateList(html, list));

            return mvc;
        }

        public static MvcHtmlString CreateList(this HtmlHelper html, string list)
        {
            string[] sIngrid = list.Split(';');

            TagBuilder ul = new TagBuilder("ul");


            foreach (string vs in sIngrid)
            {
                if (vs.Length > 2)
                {
                    TagBuilder li = new TagBuilder("li");
                    li.SetInnerText(vs);
                    ul.InnerHtml += li.ToString();
                }
            }

            return new MvcHtmlString(ul.ToString());
        }
    }
}