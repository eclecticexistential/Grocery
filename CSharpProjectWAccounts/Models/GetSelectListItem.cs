using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpProjectWAccounts.Models
{
    public class GetSelectListItem
    {
        public List<SelectListItem> GetGroceryList()
        {
            using (var inventory = new GroceryContext())
            {
                var getInventoryList = inventory.GroceryItems.ToList();
                List<SelectListItem> inventoryItemsList = new List<SelectListItem>();
                foreach (var stock in getInventoryList)
                {
                    var addItem = new SelectListItem { Text = stock.ItemName, Value = stock.Id.ToString() };
                    inventoryItemsList.Add(addItem);
                }
                return inventoryItemsList;
            }
        }
        public List<SelectListItem> GetGroceryTypes()
        {
            using (var inventory = new GroceryContext())
            {
                var getInventoryList = inventory.GroceryItems.ToList();
                List<string> stringTypes = new List<string>();
                List<SelectListItem> inventoryTypes = new List<SelectListItem>();
                foreach (var stock in getInventoryList)
                {
                    var typeInList = stringTypes.SingleOrDefault(x => x == stock.Type);
                    if (typeInList == null)
                    {
                        stringTypes.Add(stock.Type);
                        var nextType = new SelectListItem { Text = stock.Type, Value = stock.Type };
                        inventoryTypes.Add(nextType);
                    }
                }
                return inventoryTypes;
            }
        }

        public List<SelectListItem> GetGroceryFoods()
        {
            using (var inventory = new GroceryContext())
            {
                var getInventoryList = inventory.GroceryItems.ToList();
                List<string> stringCategories = new List<string>();
                List<SelectListItem> inventoryFoodCategories = new List<SelectListItem>();
                foreach (var stock in getInventoryList)
                {
                    var foodInList = stringCategories.SingleOrDefault(x => x == stock.Food);
                    if (foodInList == null)
                    {
                        stringCategories.Add(stock.Food);
                        var nextFoodCategory = new SelectListItem { Text = stock.Food, Value = stock.Food };
                        inventoryFoodCategories.Add(nextFoodCategory);
                    }
                }
                return inventoryFoodCategories;
            }
        }

        public List<SelectListItem> GetItemsByType(string foodType)
        {
            List<SelectListItem> listOfItemsToReturn = new List<SelectListItem> { };
            using (var inventory = new GroceryContext())
            {
                var getInventoryList = inventory.GroceryItems.ToList();
                List<SelectListItem> beefInInventory = new List<SelectListItem>();
                List<SelectListItem> chickenInInventory = new List<SelectListItem>();
                List<SelectListItem> porkInInventory = new List<SelectListItem>();
                List<SelectListItem> otherInInventory = new List<SelectListItem>();
                List<SelectListItem> fruitInInventory = new List<SelectListItem>();
                List<SelectListItem> vegeInInventory = new List<SelectListItem>();
                List<SelectListItem> grainInInventory = new List<SelectListItem>();
                List<SelectListItem> ingredientInInventory = new List<SelectListItem>();
                foreach (var stock in getInventoryList)
                {
                    if (stock.Food == "Meat")
                    {
                        if (stock.Type == "Cow")
                        {
                            beefInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                        if (stock.Type == "Chicken")
                        {
                            chickenInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                        if (stock.Type == "Pig")
                        {
                            porkInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                        if (stock.Type == "Fish" || stock.Type == "Turkey")
                        {
                            otherInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }

                    }
                    if (stock.Food == "Plant")
                    {
                        if (stock.Type == "Fruit")
                        {
                            fruitInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                        if (stock.Type == "Vegetable")
                        {
                            vegeInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                        if (stock.Type == "Grain")
                        {
                            grainInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                        }
                    }
                    if (stock.Food == "Ingredient")
                    {
                        ingredientInInventory.Add(new SelectListItem { Text = stock.ItemName, Value = stock.ItemName });
                    }
                }
                if(foodType == "Beef")
                {
                    return beefInInventory;
                }
                if(foodType == "Chicken")
                {
                    return chickenInInventory;
                }
                if(foodType == "Pork")
                {
                    return porkInInventory;
                }
                if(foodType == "Other")
                {
                    return otherInInventory;
                }
                if(foodType == "Fruit")
                {
                    return fruitInInventory;
                }
                if(foodType == "Vegetable")
                {
                    return vegeInInventory;
                }
                if(foodType == "Grain")
                {
                    return grainInInventory;
                }
                if(foodType == "Ingredient")
                {
                    return ingredientInInventory;
                }
                else
                {
                    //returns empty list
                    return listOfItemsToReturn;
                }
            }
        }
    }
}