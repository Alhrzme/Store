using Store.Pages.Helpers;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace Store.Pages
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int itemId;
                if (int.TryParse(Request.Form["remove"], out itemId))
                {
                    SessionHelper.GetOrder(Session).RemoveOrderItem(itemId);
                }
            }
        }

        protected string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout", null).VirtualPath;
            }
        }

        protected string ReturnUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, null, null).VirtualPath;
            }
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return SessionHelper.GetOrder(Session).OrderItems;
        }

        public decimal OrderTotal
        {
            get
            {
                return SessionHelper.GetOrder(Session).ComputeTotalValue();
            }
        }
    }
}

