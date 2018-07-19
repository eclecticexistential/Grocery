using CSharpProjectWAccounts.Models;
using System;
using System.Linq;
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

        [Authorize(Users ="admin@email.com")]
        public ActionResult UpdateInventory()
        {
            ViewBag.Message = "Welcome Back!";
            return View();
        }

        [HttpPost]
        [Authorize(Users ="admin@email.com")]
        public ActionResult UpdateInventory(Items newItem, string URL)
        {
            AdminAddItem saveImageForItem = new AdminAddItem();
            saveImageForItem.CoverImageURL(newItem.ItemName, URL);
            using (var _groceryRepoItems = new GroceryContext())
            {
                _groceryRepoItems.GroceryItems.Add(newItem);
                _groceryRepoItems.SaveChanges();
            }
            ViewBag.Message = "Item Saved.";
            return View();
        }

        [Authorize(Users = "admin@email.com")]
        public ActionResult ItemToEdit()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Users = "admin@email.com")]
        public ActionResult ItemToEdit(string ItemToEdit)
        {
            Session["ItemId"] = ItemToEdit;
            return RedirectToAction("EditInventory");
        }

        [Authorize(Users = "admin@email.com")]
        public ActionResult EditInventory()
        {
            ViewBag.Message = "Edit the Item";
            return View();
        }

        [HttpPost]
        [Authorize(Users = "admin@email.com")]
        public ActionResult EditInventory(Items newItem, string URL)
        {
            var saveHere = new AdminEdit();
            saveHere.SaveEdits(newItem, URL);
            ViewBag.Message = "Item Updated.";
            return RedirectToAction("ItemToEdit");
        }

        [Authorize(Users = "admin@email.com")]
        public ActionResult RemoveItems()
        {
            ViewBag.Message = "Pick Item to Remove";
            return View();
        }

        [HttpPost]
        [Authorize(Users = "admin@email.com")]
        public ActionResult RemoveItems(RemoveItemsForm itemsToRemove)
        {
            itemsToRemove.RemoveTheseItems();
            ViewBag.Message = "Item Removed.";
            return View();
        }
    }
}