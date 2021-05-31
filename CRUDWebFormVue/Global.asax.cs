using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CRUDWebFormVue
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        internal static DataTable ExecuteDataTable(string v)
        {
            throw new NotImplementedException();
        }

        internal static object DataTableToJson(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}