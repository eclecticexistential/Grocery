using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class ShoppingCartLogic
    {
        public void AdjustCart(int ItemId, string user, string math)
        {
            using (var _shoppingCartItems = new GroceryContext())
            {
                //gets the item from inventory
                Items inventoryItem = _shoppingCartItems.GroceryItems.SingleOrDefault(m => m.Id == ItemId);
                //finds item to be removed
                ShoppingCartItem itemRemove = _shoppingCartItems.ShoppingCartItems.FirstOrDefault(m => m.ItemId == ItemId);

                if (math == "add")
                {
                    var changeItems = new ItemToShoppingCartItemFactory();
                    string changeIdToString = ItemId.ToString();
                    changeItems.TransformItem(changeIdToString, user);
                }
                else if (math == "sub")
                {
                    _shoppingCartItems.ShoppingCartItems.Remove(itemRemove);
                    inventoryItem.Quantity += 1;
                    _shoppingCartItems.SaveChanges();

                }
                else if (math == "del")
                {
                    foreach (var item in _shoppingCartItems.ShoppingCartItems)
                    {
                        if (item.ItemId == ItemId)
                        {
                            _shoppingCartItems.ShoppingCartItems.Remove(item);
                            inventoryItem.Quantity += 1;
                        }
                    }
                    _shoppingCartItems.SaveChanges();
                }
                //deletes all items from shopping cart. ItemId is a potential placemarker for shopping cart id
                else if (math == "checkout" && ItemId == 000)
                {
                    foreach (var item in _shoppingCartItems.ShoppingCartItems)
                    {
                        _shoppingCartItems.ShoppingCartItems.Remove(item);
                    }
                    _shoppingCartItems.SaveChanges();
                }
            }
        }
    }
}