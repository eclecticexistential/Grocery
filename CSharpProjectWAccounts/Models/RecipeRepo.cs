using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class RecipeForm
    {
        public string Beef { get; set; }
        public string Chicken { get; set; }
        public string Grain { get; set; }
        public string Ingredient { get; set; }
        public string Ingredients { get; set; }
        public string Other { get; set; }
        public string Pork { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Vegetable { get; set; }
        public string Vegetables { get; set; }

        private RecipeItems newRecipe = new RecipeItems();
        public void AddFromForm()
        {
            AddIngredientList stubToUse = new AddIngredientList();
            List<string> ingredientList = new List<string> { Name, Beef, Chicken, Grain, Ingredient, Ingredients, Other, Pork, Vegetable, Vegetables};
            stubToUse.AddIngredients(ingredientList);
            using(var recipeRepoItems = new GroceryContext())
            {
                var wayToAddDes = recipeRepoItems.ListOfRecipes.SingleOrDefault(x => x.RecipeName == Name);
                wayToAddDes.Description = Description;
                recipeRepoItems.SaveChanges();
            }
        }
    }
}