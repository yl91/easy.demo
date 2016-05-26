using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Easy.Rpc.directory;
using System.IO;
using Easy.Public;
using Easy.Public.MyLog;
using Easy.Rpc.Monitor;

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


            var isRegsiterToRegiserCenter = StringHelper.ToInt32(ConfigurationManager.AppSettings["isRegsiterToRegiserCenter"], 1);
            if (isRegsiterToRegiserCenter == 1)
            {
                string registerUrl = ConfigurationManager.AppSettings["registerUrl"];
                string redisUrl = ConfigurationManager.AppSettings["redisUrl"];
                int databaseIndex = int.Parse(ConfigurationManager.AppSettings["databaseIndex"]);
                var builder = new RedisDirectoryBuilder(registerUrl, redisUrl, databaseIndex);
                builder.Build(new MySelfInfo()
                {
                    Description = "Demo站点",
                    Directory = "DemoWebSite",
                    Status = 1,
                    Weight = 10,
                    Url = string.Format("http://{0}", IpHelper.InternetIp4()),
                    Ip = string.Format("{0}:{1}",IpHelper.InternetIp4(),80)
                }, new string[1] { "ServiceDemo" }, new string[0]);

                //string monitorUrl = ConfigurationManager.AppSettings["monitorUrl"];
                //MonitorManager.RegisterSend(new HttpSendCollectorData(monitorUrl));
            }
            //if (ConfigurationManager.AppSettings["remoteLog"] == "true")
            //{
            //    LogManager.Register(new RemoteLogger() { Url = "http://101.200.124.233:3100/logH5" });
            //}


            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EasyDemo.config");
            Easy.Rpc.directory.DirectoryFactory.Register("EasyDemo", new StaticDirectory(path, "EasyDemo"));
        }
    }
}
