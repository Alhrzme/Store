using System;
using System.Web.Routing;
using Store.Models;

namespace Store.Pages
{
    public partial class ItemPage : System.Web.UI.Page
    {
        protected Item CurrentItem
        {
            get
            {
                return ItemsDB.GetItemByID(CurrentItemID);
            }
        }

        protected int CurrentItemID
        {
            get
            {
                int id;
                string reqValue = (string)RouteData.Values["id"] ??
                    Request.QueryString["id"];
                return reqValue != null && int.TryParse(reqValue, out id) ? id : 1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
        }

        public string GetImageLink()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, "RouteDataHandler",
                new RouteValueDictionary()
                {
                    {
                        "id", CurrentItemID
                    }
                }
                ).VirtualPath;
            return string.Format("<img src='{0}' alt=\"Image\" />", path);
        }
    }
}