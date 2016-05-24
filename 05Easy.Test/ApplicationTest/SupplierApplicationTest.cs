using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Easy.Application;
using Easy.Application.Models;
using Easy.Application.Models.Supplier;
using Easy.Domain.Application;
using Easy.Public.MyLog;
using NUnit.Framework;

namespace Easy.Test.ApplicationTest
{

    public class SupplierApplicationTest
    {

        [TestFixtureSetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void AddTest()
        {
            var model = new AddSupplierModel()
            {
                Address = "北京市朝阳区",BusinessTimeStart = new TimeModel(){Hour = 8,Minute = 0},BusinessTimeEnd = new TimeModel(){Hour = 20,Minute = 0},CoordinatesLatitude = "42.324",CoordinatesLongitude = "152.324",DeliveryTime = new DeliveryTime[]{new DeliveryTime(){Start = new TimeModel(){Hour = 11,Minute = 0},End = new TimeModel(){Hour = 13,Minute = 30}} },
                Name = "测试",Tel = "13888888888"
            };
            IReturn @iReturn= ApplicationRegistry.Supplier.Add(model);
            ResultWithData<bool> result= @iReturn.Result(new ReturnContext() { SystemId = "app"});

            
        }

        [Test]
        public void AddTestH5()
        {
            var model = new AddSupplierModel()
            {
                Address = "北京市朝阳区",
                BusinessTimeStart = new TimeModel() { Hour = 8, Minute = 0 },
                BusinessTimeEnd = new TimeModel() { Hour = 20, Minute = 0 },
                CoordinatesLatitude = "42.324",
                CoordinatesLongitude = "152.324",
                DeliveryTime = new DeliveryTime[] { new DeliveryTime() { Start = new TimeModel() { Hour = 11, Minute = 0 }, End = new TimeModel() { Hour = 13, Minute = 30 } } },
                Name = "测试",
                Tel = "13888888888"
            };
            IReturn @iReturn = ApplicationRegistry.Supplier.Add(model);
            ResultWithData<string> result = @iReturn.Result(new ReturnContext() { SystemId = "h5" });
            
        }

        [Test]
        public void AddTestH5V2()
        {
            var model = new AddSupplierModel()
            {
                Address = "北京市朝阳区",
                BusinessTimeStart = new TimeModel() { Hour = 8, Minute = 0 },
                BusinessTimeEnd = new TimeModel() { Hour = 20, Minute = 0 },
                CoordinatesLatitude = "42.324",
                CoordinatesLongitude = "152.324",
                DeliveryTime = new DeliveryTime[] { new DeliveryTime() { Start = new TimeModel() { Hour = 11, Minute = 0 }, End = new TimeModel() { Hour = 13, Minute = 30 } } },
                Name = "测试",
                Tel = "13888888888"
            };
            IReturn @iReturn = ApplicationRegistry.Supplier.Add(model);
            ResultWithData<string> result = @iReturn.Result(new ReturnContext() { SystemId = "h5" ,Version = "1"});
            
        }

        [Test]
        public void GetById()
        {
            //var model = new AddSupplierModel()
            //{
            //    Address = "北京市朝阳区",
            //    BusinessTimeStart = new TimeModel() { Hour = 8, Minute = 0 },
            //    BusinessTimeEnd = new TimeModel() { Hour = 20, Minute = 0 },
            //    CoordinatesLatitude = "42.324",
            //    CoordinatesLongitude = "152.324",
            //    DeliveryTime = new DeliveryTime[] { new DeliveryTime() { Start = new TimeModel() { Hour = 11, Minute = 0 }, End = new TimeModel() { Hour = 13, Minute = 30 } } },
            //    Name = "测试",
            //    Tel = "13888888888"
            //};
            //IReturn @iReturn = ApplicationRegistry.Supplier.Add(model);
            //ResultWithData<bool> result = @iReturn.Result(new ReturnContext() { SystemId = "app" });

            
            //IReturn @iReturn2= ApplicationRegistry.Supplier.Select(20, 1);
            //ResultWithData<PageList<dynamic>> result2 = @iReturn2.Result(new ReturnContext() { SystemId = "app" });

            //var obj = result2.DataBody.Collections.FirstOrDefault<dynamic>();
            //PropertyInfo propertyInfo = obj.GetType().GetProperty("Id");
            //var id= propertyInfo.GetValue(obj, null);

            //IReturn @iReturn3= ApplicationRegistry.Supplier.GetById(id);
            //ResultWithData<DetailSupplierModel> result3= @iReturn3.Result(new ReturnContext(){ SystemId = "app"});

            //Assert.IsTrue(result3.DataBody.Id>0);
        }

        [Test]
        public void FindByIds()
        {
            
            //ApplicationRegistry.Supplier.FindByIds()
        }

        public AddSupplierModel Create()
        {
            var model = new AddSupplierModel()
            {
                Address = "北京市朝阳区",
                BusinessTimeStart = new TimeModel() { Hour = 8, Minute = 0 },
                BusinessTimeEnd = new TimeModel() { Hour = 20, Minute = 0 },
                CoordinatesLatitude = "42.324",
                CoordinatesLongitude = "152.324",
                DeliveryTime = new DeliveryTime[] { new DeliveryTime() { Start = new TimeModel() { Hour = 11, Minute = 0 }, End = new TimeModel() { Hour = 13, Minute = 30 } } },
                Name = "测试",
                Tel = "13888888888"
            };
            return model;
        }


        [TearDown]
        public void Clear()
        {
            IReturn @iReturn = ApplicationRegistry.Supplier.RemoveAll();
            ResultWithData<bool> result = @iReturn.Result(new ReturnContext() { SystemId = "app" });
        }
    }
}
