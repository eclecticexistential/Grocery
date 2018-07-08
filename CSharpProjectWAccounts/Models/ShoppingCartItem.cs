
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserId
        {
            get
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                if(user != null)
                {
                    return user.Id;
                }
                else
                {
                    return null;
                }
            }
            set { }
        }
        public virtual Items Item { get; set; }
    }
}