using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Store.Pages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Form["logout"] != null)
                {
                    FormsAuthentication.SignOut();
                    string loginUrl = RouteTable.Routes.GetVirtualPath(null, "login", null).VirtualPath;
                    Response.Redirect(loginUrl);
                }
            }
        }

        
    }
}