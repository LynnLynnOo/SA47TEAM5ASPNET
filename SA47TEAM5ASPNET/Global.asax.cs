using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SA47TEAM5ASPNET
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["cartItems"] = new List<CartItem>();
            Session["total"] = String.Empty;
            Session["discountTotal"] = String.Empty;
            Session["discountedTotal"] = String.Empty;
            Session["promoCode"] = String.Empty;
        }



    }
}