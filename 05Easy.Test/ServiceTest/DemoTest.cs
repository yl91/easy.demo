using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Easy.Services;

namespace Easy.Test.ServiceTest
{
    public class DemoTest
    {
        [Test]
        public void SayHelloTest()
        {
            ResultWithData<string> result= ServicesRegistry.Demo.SayHello("aa", 18);
            
        }
    }
}
