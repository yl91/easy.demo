using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Easy.Application.Models
{
    /// <summary>
    /// 返回对象
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int Success = 200;
        /// <summary>
        /// 服务器错误
        /// </summary>
        public const int ServerError = 500;
        /// <summary>
        /// 未授权
        /// </summary>
        public const int NoAutherize = 401;
        /// <summary>
        /// 构造bb函数
        /// </summary>
        public Result()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public Result(int status, String message = "")
        {
            this.ResultStatus = status;
            this.Message = message;
        }
        /// <summary>
        /// 返回状态(200:成功  500:服务器错误)
        /// </summary>
        [JsonProperty]
        public int ResultStatus;
        /// <summary>
        /// 返回的消息 
        /// </summary>
        [JsonProperty]
        public String Message;
    }
    /// <summary>
    /// 返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultWithData<T> : Result
    {
        /// <summary>
        /// 
        /// </summary>
        public ResultWithData()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dataBody"></param>
        /// <param name="message"></param>
        public ResultWithData(int status, T dataBody, String message = "")
            : base(status, message)
        {
            this.DataBody = dataBody;
        }
        /// <summary>
        /// 返回的数据信息
        /// </summary>
        [JsonProperty]
        public T DataBody
        {
            get;
            private set;
        }
    }

    public enum ResultStatus
    {
        Ok = 200,
        Error = 500
    }
}
