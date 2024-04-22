using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LandfillServices.UI.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
                setUser();
        }
        private static void setUser()
        {
            ObjectsFunctions.LandfillUser user =ControllerFunctions.LandfilluserController.SearchByID(int.Parse(HttpContext.Current.User.Identity.Name));
            if (user != null)
                HttpContext.Current.User = user;
            else
                HttpContext.Current.User = null;
        }
    }
}