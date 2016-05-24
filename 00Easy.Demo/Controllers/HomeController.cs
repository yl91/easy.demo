using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Application;
using Easy.Application.Models;
using Easy.Application.Models.Supplier;
using Easy.Domain.Application;

namespace _00Easy.Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IReturn @iReturn= ApplicationRegistry.Supplier.Select(20, 1);
            ResultWithData<PageList<SelectModel>> result= @iReturn.Result(new ReturnContext(){ SystemId = "app"});

            var data = result.DataBody.Collections;
            ViewBag.data = data;

            return View();
        }

        public ActionResult Test()
        {
            var model = new AddSupplierModel()
            {
                Address = "北京市朝阳区111",BusinessTimeStart = new TimeModel(){Hour = 8,Minute = 0},BusinessTimeEnd = new TimeModel(){Hour = 20,Minute = 0},CoordinatesLatitude = "42.324",CoordinatesLongitude = "152.324",DeliveryTime = new DeliveryTime[]{new DeliveryTime(){Start = new TimeModel(){Hour = 11,Minute = 0},End = new TimeModel(){Hour = 13,Minute = 30}} },
                Name = "测试",Tel = "13888888888"
            };

            ApplicationRegistry.Supplier.Add(model);

            ViewBag.Name = "哈哈哈，天气不错哟~";
            return View();
        }

        public JsonResult Demo()
        {
            IReturn @IReturn= ApplicationRegistry.Demo.SayHello("zhangsan", 20);
            var result= @IReturn.Result(new ReturnContext() {SystemId = "app"});
            return null;
        }
    }
}