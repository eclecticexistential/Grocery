using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class Items
    {
        public Items()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            ListOfRecipes = new List<RecipeItems>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Food { get; set; }

        public string CoverImageFileName => ItemName.Replace(" ", "").ToLower() + ".jpg";

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<RecipeItems> ListOfRecipes { get; set; }
    }

}