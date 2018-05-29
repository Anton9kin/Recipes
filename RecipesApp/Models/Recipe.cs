using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesApp.Models
{
    public enum TypeCourse{ Soup, SecondCourse, Salad, Snak, Bake, Dessert, Drink};

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeCourse Type { get; set; }
        public string Image { get; set; }
        public string Ingridient { get; set; }
        public string Cooking { get; set; }
    }
}