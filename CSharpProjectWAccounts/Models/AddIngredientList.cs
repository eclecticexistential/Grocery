using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class AddIngredientList
    {
        public AddIngredientList()
        {
            using (var _groceryRepoItems = new GroceryContext())
            {
                var inventory = _groceryRepoItems.GroceryItems.ToArray();
                var recipeListNames = _groceryRepoItems.ListOfRecipes.ToArray();
                if (recipeListNames.Length == 2)
                {
                    List<List<string>> initialIngredientList = new List<List<string>> { };
                    List<string> potatoSoupIds = new List<string> { "Potato Soup", "Potato", "Milk", "Butter", "Pepper", "Salt", "Bacon", "Celery", "Onion", "Vegetable Broth" };
                    List<string> chicBrocRice = new List<string> { "Chicken Broccoli Rice", "Chicken Breast", "White Rice", "Broccoli", "Pepper", "Vegetable Broth", "Salt" };
                    initialIngredientList.Add(potatoSoupIds);
                    initialIngredientList.Add(chicBrocRice);
                    foreach(var oneRecipe in recipeListNames)
                    {
                        if(oneRecipe.Item.Count == 0)
                        {
                            foreach (var ingredientList in initialIngredientList)
                            {
                                AddIngredients(ingredientList);
                            };
                        }
                    }
                }
            }
        }
        public void AddIngredients(List<string> ingredientList)
        {
            using (var _groceryRepoItems = new GroceryContext())
            {
                var inventory = _groceryRepoItems.GroceryItems.ToArray();
                var recipeList = _groceryRepoItems.ListOfRecipes.ToArray();
                var oneRecipe = recipeList.SingleOrDefault(x => x.RecipeName == ingredientList[0]);

                List<Items> updateList = new List<Items> { };
                foreach (var ingredient in ingredientList)
                {
                    var addThis = inventory.SingleOrDefault(x => x.ItemName == ingredient);
                    if (addThis != null)
                    {
                        updateList.Add(addThis);
                    }
                }

                if (oneRecipe != null)
                {
                    oneRecipe.Item = updateList;
                    _groceryRepoItems.SaveChanges();
                }
                if(oneRecipe == null)
                {
                    string recipeName = ingredientList[0];
                    RecipeItems newRecipe = new RecipeItems()
                    {
                        RecipeName = recipeName
                    };
                    newRecipe.Item = updateList;
                    _groceryRepoItems.ListOfRecipes.Add(newRecipe);
                    _groceryRepoItems.SaveChanges();
                }
                
                
            }
        }
    }
}