using Store.Models;
using Store.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order myOrder = SessionHelper.GetOrder(Session);
            csQuantity.InnerText = myOrder.OrderItems.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = myOrder.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
        }
    }
}