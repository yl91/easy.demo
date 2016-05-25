using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Easy.Rpc.directory;
using System.IO;

namespace _00Easy.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DirectoryFactory.Register("EasyDemo", new StaticDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "servicedemo.config"), "EasyDemo"));

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EasyDemo.config");
            Easy.Rpc.directory.DirectoryFactory.Register("EasyDemo", new StaticDirectory(path, "EasyDemo"));
        }
    }
}
