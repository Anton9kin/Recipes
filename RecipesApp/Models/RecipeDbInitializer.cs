using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RecipesApp.Models
{
    public class RecipeDbInitializer : DropCreateDatabaseAlways<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            context.Recipes.Add(new Recipe { Name = "Борщ", Ingridient = "Свекла, Капуста, Вода", Cooking = "Все смешать и варить", Image = "soap/pic/borsh.png", Link="soap/borsh.html" });

            base.Seed(context);
        }
    }
}