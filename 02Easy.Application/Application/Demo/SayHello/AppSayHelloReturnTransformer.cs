using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;

namespace Easy.Application.Application.Demo.SayHello
{
    public class AppSayHelloReturnTransformer : AppReturnTransFormer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
            string str = data.ToString();
            return this.ResultValue(data: str);
        }
    }
}
