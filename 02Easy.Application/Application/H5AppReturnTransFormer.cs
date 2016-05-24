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
    public abstract class H5AppReturnTransFormer:IReturnTransformer
    {
        /// <summary>
        /// 使用顺序，越大越先使用
        /// </summary>
        public virtual int Order
        {
            get { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract dynamic GetValue(ReturnContext context, object data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool IsMapped(ReturnContext context)
        {
            int v = StringHelper.ToInt32(context.Version, 0);
            if (context.SystemId.ToUpper() == "H5" && v >= this.Order)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public dynamic ResultValue<T>(int status = 200, T data = default(T), string message = "")
        {
            var result = new ResultWithData<T>(status, data, message);
            return result;
        }
    }

    public abstract class H5AppReturnTransFormerV2 : IReturnTransformer
    {
        /// <summary>
        /// 使用顺序，越大越先使用
        /// </summary>
        public virtual int Order
        {
            get { return 1; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract dynamic GetValue(ReturnContext context, object data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool IsMapped(ReturnContext context)
        {
            int v = StringHelper.ToInt32(context.Version, 0);
            if (context.SystemId.ToUpper() == "H5" && v >= this.Order)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public dynamic ResultValue<T>(int status = 200, T data = default(T), string message = "")
        {
            var result = new ResultWithData<T>(status, data, message);
            return result;
        }
    }
}
