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
            context.Recipes.Add(new Recipe { Name = "Солянка", Type = "Супы", Ingridient = "Сосиски — 2 шт. Лук — 1 шт. Морковь — 2 шт. Картофель -2 шт. Огурцы корнишоны — 5 шт. Оливки — 1 банка Лимон — 4 кружочка Подсолнечное масло Томатная паста — 2 ст. ложки", Cooking = "Все смешать и варить"});
            context.Recipes.Add(new Recipe { Name = "Салат из креветок", Type = "Салаты", Ingridient = "Ингредиенты (на 4 порции): Креветок - 500 гр. Яйца - 3 шт. Огурец - 1 шт. (большой) Чеснок - 1 зубчик свежий укроп соль, перец майонез", Cooking = "Все смешать "});
            context.Recipes.Add(new Recipe { Name = "Горячие бутерброды со шпротами", Type = "Закуски", Ingridient = "Шпроты - 1 банка Батон Помидоры Сыр Кетчуп томатный Чеснок", Cooking = "Все смешать "});
            context.Recipes.Add(new Recipe { Name = "Молочный коктейль", Type = "Напитки", Ingridient = "Молоко Мороженое Бананы (ягоды) Какао", Cooking = "Все смешать "});


            base.Seed(context);
        }
        
    }
}