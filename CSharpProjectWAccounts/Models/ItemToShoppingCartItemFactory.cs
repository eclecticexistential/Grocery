using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class ItemToShoppingCartItemFactory
    {
        public void TransformItem(string Id, string UserName)
        {
            //gets id number from string post
            int id = Int32.Parse(Id);
            using (var _groceryRepoItems = new GroceryContext())
            {
                Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                ShoppingCartItem addThis = new ShoppingCartItem
                {
                    Item = inventoryItem
                };
                addThis.UserId = UserName;
                _groceryRepoItems.ShoppingCartItems.Add(addThis);
                inventoryItem.Quantity -= 1;
                _groceryRepoItems.SaveChanges();
            }
        }
    }
}