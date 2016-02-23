using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Store.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string OrdersUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "admin_orders", null).VirtualPath;
            }
        }

        public string AddingItemUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "add_item", null).VirtualPath;
            }
        }

        public string TrafficUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "webSiteTraffic", null).VirtualPath;
            }
        }

        public string RegistrationUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "admin_registration", null).VirtualPath;
            }
        }

    }
}