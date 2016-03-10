using Store.Pages.Helpers;
using Store.Models;
using System.Web;
using System.Web.Services;

namespace Store
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AjaxWebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void AddOrderItemToOrder(int quantity, int itemId)
        {
            Item item = ItemsDB.GetItemByID(itemId);
            SessionHelper.GetOrder(HttpContext.Current.Session).AddItem(item, quantity);
        }
    }
}
