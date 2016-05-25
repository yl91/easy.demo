using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Application;
using Easy.Application.Models;
using Easy.Domain.Application;

namespace _00Easy.Demo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            IReturn @IReturn = ApplicationRegistry.Demo.SayHello("zhangsan", 20);
            ResultWithData<string> result = @IReturn.Result(new ReturnContext() { SystemId = "app" });

            ViewBag.data = result.DataBody;
            return View();
        }


    }
}