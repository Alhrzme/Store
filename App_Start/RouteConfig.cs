using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/ItemList.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/ItemList.aspx");
            
            routes.MapPageRoute(null, "", "~/Pages/ItemList.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/ItemList.aspx");

            routes.MapPageRoute("login", "login", "~/Pages/LoginPage.aspx");

            routes.MapPageRoute("cart", "cart", "~/Pages/Cart.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");

            routes.MapPageRoute("admin_registration", "admin/registration", "~/Pages/Admin/Registration.aspx");
            routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
            routes.MapPageRoute("add_item", "admin/addingItem", "~/Pages/Admin/AddingItem.aspx");
            routes.MapPageRoute("webSiteTraffic", "admin/websiteTraffic", "~/Pages/Admin/WebsiteTraffic.aspx");

            routes.Add("RouteDataHandler", new Route("GetImage/{id}",
                new Pages.Helpers.BaseDataHandler<Pages.Helpers.GetImageHandler>()));

            routes.MapPageRoute("item", "item", "~/Pages/ItemPage.aspx");

        }
    }
}