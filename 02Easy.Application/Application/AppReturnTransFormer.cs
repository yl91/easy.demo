using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Models;
using Easy.Domain.Application;
using Easy.Public;

namespace Easy.Application.Application
{
    public abstract class AppReturnTransFormer:IReturnTransformer
    {

        public abstract dynamic GetValue(ReturnContext context, object data);

        public bool IsMapped(ReturnContext context)
        {
            int v = StringHelper.ToInt32(context.Version, 0);
            if (context.SystemId.ToUpper() == "APP" && v >= this.Order)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 使用顺序，越大越先使用
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        public dynamic ResultValue<T>(int status = 200, T data = default(T), string message = "")
        {
            var result = new ResultWithData<T>(status, data, message);
            return result;
        }
    }
}
