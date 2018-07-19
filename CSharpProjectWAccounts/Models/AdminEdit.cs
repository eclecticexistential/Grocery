using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class AdminEdit
    {
        public void SaveEdits(Items newItem, string URL)
        {
            using (var _groceryRepoItems = new GroceryContext())
            {
                var itemToEdit = _groceryRepoItems.GroceryItems.SingleOrDefault(x => x.Id == newItem.Id);
                AdminAddItem saveImageForItem = new AdminAddItem();
                if (URL != "")
                {
                    saveImageForItem.CoverImageURL(newItem.ItemName, URL);
                }
                if (itemToEdit != newItem)
                {
                    if (itemToEdit.ItemName != newItem.ItemName && URL == "")
                    {
                        saveImageForItem.UpdateImageLocation(itemToEdit.ItemName, newItem.ItemName);
                    }
                    if (newItem.Type == null)
                    {
                        newItem.Type = itemToEdit.Type;
                    }
                    if (newItem.Food == null)
                    {
                        newItem.Food = itemToEdit.Food;
                    }
                    if (newItem.ItemName == null)
                    {
                        newItem.ItemName = itemToEdit.ItemName;
                    }
                    _groceryRepoItems.GroceryItems.Remove(itemToEdit);
                    _groceryRepoItems.GroceryItems.Add(newItem);
                    _groceryRepoItems.SaveChanges();
                }
            }
        }
    }
}