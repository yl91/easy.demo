using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Domain.ServiceFramework;
using Easy.Services;


namespace Easy.Application.Application
{
    public class DemoApplication:BaseApplication
    {
        public IReturn SayHello(string name, int age)
        {
          
            var result = ServicesRegistry.Demo.SayHello(name,age);

            return this.Write("SayHello", result.DataBody);
        }
    }
}