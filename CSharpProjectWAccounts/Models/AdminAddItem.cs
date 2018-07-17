using System.Net;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class AdminAddItem
    {
        public void CoverImageURL(string itemName, string URL)
        {
            var fString = HttpContext.Current.Server.MapPath("/Images");
            string saveImgHere = fString + "/" + itemName;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(URL, saveImgHere);
            webClient.Dispose();
        }

        public void UpdateImageLocation(string oldName, string newName)
        {
            var imageOLocated = HttpContext.Current.Server.MapPath("/Images/" + oldName);
            var imageNLocation = HttpContext.Current.Server.MapPath("/Images/");
            System.IO.File.Move(imageOLocated, imageNLocation + newName);
        }
    }
}