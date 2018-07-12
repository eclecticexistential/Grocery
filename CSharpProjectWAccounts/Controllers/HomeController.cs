using CSharpProjectWAccounts.Models;
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
            if (ModelState.IsValid)
            {
                var ItemToShoppingCartItemFactory = new ItemToShoppingCartItemFactory();
                var user = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                ItemToShoppingCartItemFactory.TransformItem(Item, user);
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
            if (ModelState.IsValid)
            {
                var ItemToShoppingCartItemFactory = new ItemToShoppingCartItemFactory();
                var user = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                ItemToShoppingCartItemFactory.TransformItem(Item, user);
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
            if (ModelState.IsValid)
            {
                var ItemToShoppingCartItemFactory = new ItemToShoppingCartItemFactory();
                var user = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                ItemToShoppingCartItemFactory.TransformItem(Item, user);
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
                    var ItemToShoppingCartItemFactory = new ItemToShoppingCartItemFactory();
                    var user = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                    foreach (var name in matchRecipeName.Item)
                    {
                        ItemToShoppingCartItemFactory.TransformItem(name.Id.ToString(), user);
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

        [Authorize]
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
                var user = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                var cartLogic = new ShoppingCartLogic();
                cartLogic.AdjustCart(ItemId, user, math);
                return RedirectToAction("ShoppingCart");
            }
            return View();
        }
		
		
    }
}