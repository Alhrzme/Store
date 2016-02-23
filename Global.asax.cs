using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.Optimization;

namespace Store
{
    public class Global : System.Web.HttpApplication
    {
        public static int[] VisiterCounter = new int[24];

        public static int CurrentHour
        {
            get;
            set;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CurrentHour = DateTime.Now.Hour;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            IncreaseCounter();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void IncreaseCounter()
        {
            int currentHour = DateTime.Now.Hour;
            if (currentHour != CurrentHour)
            {
                VisiterCounter[currentHour] = 0;
                CurrentHour = currentHour;
            }
            VisiterCounter[currentHour]++;
        }
    }
}