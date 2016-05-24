using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Domain.Model
{
    public class SupplierBrokenRuleMessage : BrokenRuleMessage
    {
        public const string NameIsEmpty = "10001";
        public const string NameLengthIsOut = "10002";
        public const string AddressIsEmpty = "10003";
        public const string AddressLengthIsOut = "10004";
        public const string TelIsEmpty = "10005";
        public const string TelIsTooLong = "10006";
        public const string TelStringError = "10007";
        public const string CoordinatesError = "10008";
        public const string BussinessTimeError = "10009";
        public const string DeliveryTimeError = "10010";

        protected override void PopulateMessage()
        {
            this.Messages.Add(NameIsEmpty, "餐厅名称不能为空");
            this.Messages.Add(NameLengthIsOut, "餐厅名称不能超过20个字符");
            this.Messages.Add(AddressIsEmpty, "地址不能为空");
            this.Messages.Add(AddressLengthIsOut, "地址长度不能超过100个字符");
            this.Messages.Add(TelIsEmpty, "电话不能为空");
            this.Messages.Add(TelIsTooLong, "电话号码不能超过11位");
            this.Messages.Add(CoordinatesError, "地理坐标不能为空");
            this.Messages.Add(BussinessTimeError, "营业时间错误");
        }
    }
}
