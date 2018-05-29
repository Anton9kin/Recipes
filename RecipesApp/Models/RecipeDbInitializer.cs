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
            context.Recipes.Add(new Recipe { Name = "Солянка", Type= TypeCourse.Soup, Ingridient = "Сосиски — 2 шт. Лук — 1 шт. Морковь — 2 шт. Картофель -2 шт. Огурцы корнишоны — 5 шт. Оливки — 1 банка Лимон — 4 кружочка Подсолнечное масло Томатная паста — 2 ст. ложки", Cooking = "Все смешать и варить", Image = "soap/pic/borsh.png" });
            context.Recipes.Add(new Recipe { Name = "Салат из креветок", Type = TypeCourse.Salad, Ingridient = "Ингредиенты (на 4 порции): Креветок - 500 гр. Яйца - 3 шт. Огурец - 1 шт. (большой) Чеснок - 1 зубчик свежий укроп соль, перец майонез", Cooking = "Все смешать ", Image = "soap/pic/borsh.png" });
            context.Recipes.Add(new Recipe { Name = "Горячие бутерброды со шпротами", Type = TypeCourse.Snak, Ingridient = "Шпроты - 1 банка Батон Помидоры Сыр Кетчуп томатный Чеснок", Cooking = "Все смешать ", Image = "soap/pic/borsh.png" });
            context.Recipes.Add(new Recipe { Name = "Молочный коктейль", Type = TypeCourse.Drink, Ingridient = "Молоко Мороженое Бананы (ягоды) Какао", Cooking = "Все смешать ", Image = "soap/pic/borsh.png" });


            base.Seed(context);
        }
        
    }
}