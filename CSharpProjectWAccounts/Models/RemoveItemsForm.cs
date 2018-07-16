using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class RemoveItemsForm
    {
        public string Beef { get; set; }
        public string Chicken { get; set; }
        public string Grain { get; set; }
        public string Ingredient { get; set; }
        public string Other { get; set; }
        public string Pork { get; set; }
        public string Vegetable { get; set; }
        public void RemoveTheseItems()
        {
            using(var _groceryList = new GroceryContext())
            {
                if(Beef != null)
                {
                    var beefRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Beef);
                    _groceryList.GroceryItems.Remove(beefRem);
                }
                if (Chicken != null)
                {
                    var chicRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Chicken);
                    _groceryList.GroceryItems.Remove(chicRem);
                }
                if (Grain != null)
                {
                    var graRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Grain);
                    _groceryList.GroceryItems.Remove(graRem);
                }
                if (Ingredient != null)
                {
                    var ingRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Ingredient);
                    _groceryList.GroceryItems.Remove(ingRem);
                }
                if (Other != null)
                {
                    var othRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Other);
                    _groceryList.GroceryItems.Remove(othRem);
                }
                if (Pork != null)
                {
                    var porkRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Pork);
                    _groceryList.GroceryItems.Remove(porkRem);
                }
                if (Vegetable != null)
                {
                    var vegeRem = _groceryList.GroceryItems.SingleOrDefault(x => x.ItemName == Vegetable);
                    _groceryList.GroceryItems.Remove(vegeRem);
                }
                _groceryList.SaveChanges();
            }
        }

    }
}