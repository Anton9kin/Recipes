﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Ingridient { get; set; }
        public string Cooking { get; set; }
        public string Link { get; set; }
    }
}