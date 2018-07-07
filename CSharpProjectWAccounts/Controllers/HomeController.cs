
using CSharpProjectWAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpProjectWAccounts.Controllers
{
    public class HomeController : Controller
    {
		static HomeController()
        {
            using (var _groceryRepoItems = new GroceryContext())
            {
                var recipeCheck = _groceryRepoItems.ListOfRecipes.ToArray();
                if (recipeCheck[0].Item.Count == 0)
                {
                    AddIngredientList addInitialRecipe = new AddIngredientList();
                }
            }
        }
        public HomeController()
        {
            //creates shopping cart array for viewbag prop
            using (var _shoppingCart = new GroceryContext())
            {
                var shoppingCartQuery = from ci in _shoppingCart.ShoppingCartItems select ci;
                var shoppingCartList = shoppingCartQuery.ToList();
                ViewBag._shoppingCart = shoppingCartList.ToArray();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
		public ActionResult Plant()
        {
            ViewBag.Message = "Food You Need to Feel Healthy and Live Well";
            //loads plant page with full array of grocery items
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
		[Authorize]
        public ActionResult Plant(string Item)
        {
            //gets id number from string post
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Plant");
            }
            else
            {
                return View();
            }
        }
		public ActionResult Meat()
        {
            ViewBag.Message = "Animal Protein to Refuel";
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
		[Authorize]
        public ActionResult Meat(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Meat");
            }
            else
            {
                return View();
            }
        }
		
		public ActionResult Baking()
        {
            ViewBag.Message = "Items You Need to Bake, Season, and Create Deliciousness";
            using (var _groceryRepoItems = new GroceryContext())
            {
                return View(_groceryRepoItems.GroceryItems.ToArray());
            }
        }

        [HttpPost]
		[Authorize]
        public ActionResult Baking(string Item)
        {
            int id = Int32.Parse(Item);
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.Id == id);
                    ShoppingCartItem addThis = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    _groceryRepoItems.ShoppingCartItems.Add(addThis);
                    inventoryItem.Quantity -= 1;
                    _groceryRepoItems.SaveChanges();
                }
                return RedirectToAction("Baking");
            }
            else
            {
                return View();
            }
        }
		public ActionResult Recipes()
        {
            ViewBag.Message = "Meal Ideas to Spice Things Up";

            return View();
        }

        [HttpPost]
		[Authorize]
        public ActionResult Recipes(string recipeName)
        {
            if (ModelState.IsValid)
            {
                using (var _groceryRepoItems = new GroceryContext())
                {
                    var matchRecipeName = _groceryRepoItems.ListOfRecipes.SingleOrDefault(m => m.RecipeName == recipeName);
                    foreach (var name in matchRecipeName.Item)
                    {
                        Items inventoryItem = _groceryRepoItems.GroceryItems.SingleOrDefault(m => m.ItemName == name.ItemName);
                        ShoppingCartItem addThis = new ShoppingCartItem
                        {
                            Item = inventoryItem
                        };
                        _groceryRepoItems.ShoppingCartItems.Add(addThis);
                        inventoryItem.Quantity -= 1;
                        _groceryRepoItems.SaveChanges();
                    }
                }
                return RedirectToAction("Recipes");
            }
            else
            {
                return View();
            }
        }
		public ActionResult AddRecipe()
        {
            ViewBag.Message = "Create A New Recipe";
            return View();
        }

        [HttpPost]
		[Authorize]
        public ActionResult AddRecipe(RecipeForm form)
        {
            if (ModelState.IsValid)
            {
                form.AddFromForm();
                return RedirectToAction("Recipes");
            }
            else
            {
                return View();
            }
        }
		public ActionResult ShoppingCart()
        {
            ViewBag.Message = "Items in Your Shopping Cart";
            return View();
        }

        [HttpPost]
		[Authorize]
        public ActionResult ShoppingCart(int ItemId, string math)
        {
            if (ModelState.IsValid)
            {
                using (var _shoppingCartItems = new GroceryContext())
                {
                    //gets the item from inventory
                    Items inventoryItem = _shoppingCartItems.GroceryItems.SingleOrDefault(m => m.Id == ItemId);
                    //finds item to be removed
                    ShoppingCartItem itemRemove = _shoppingCartItems.ShoppingCartItems.FirstOrDefault(m => m.ItemId == ItemId);
                    //transforms inventory item to shopping cart item
                    ShoppingCartItem cartItem = new ShoppingCartItem
                    {
                        Item = inventoryItem
                    };
                    if (math == "add")
                    {
                        _shoppingCartItems.ShoppingCartItems.Add(cartItem);
                        //logic for when quantity reduction goes over quantity amount is not yet created.
                        inventoryItem.Quantity -= 1;
                        _shoppingCartItems.SaveChanges();
                    }
                    else if (math == "sub")
                    {
                        _shoppingCartItems.ShoppingCartItems.Remove(itemRemove);
                        inventoryItem.Quantity += 1;
                        _shoppingCartItems.SaveChanges();
                        
                    }
                    else if (math == "del")
                    {
                        //removes all instances of item in shopping cart. probably a better way to do this.
                        foreach(var item in _shoppingCartItems.ShoppingCartItems)
                        {
                            if(item.ItemId == ItemId)
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
                    return RedirectToAction("ShoppingCart");
                }
            }
            return View();
        }
		
		
    }
}