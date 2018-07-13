using System.Net;
using System.Web;

namespace CSharpProjectWAccounts.Models
{
    public class AdminAddItem : Items
    {
        public void CoverImageURL(string URL)
        {
            var fString = HttpContext.Current.Server.MapPath("/Images");
            string saveImgHere = fString + "/" + CoverImageFileName;
            WebClient webClient = new WebClient();
            webClient.DownloadFile(URL, saveImgHere);
            webClient.Dispose();
        }
    }
}