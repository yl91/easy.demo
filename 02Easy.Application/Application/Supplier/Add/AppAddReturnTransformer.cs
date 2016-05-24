using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using M = Easy.Domain.Model;

          
namespace Easy.Application.Application.Supplier.Add
{
    public class AppAddReturnTransformer : AppReturnTransFormer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
            var supplier= data as M.Supplier;
            if (supplier.GetBrokenRules().Count > 0)
            {
                var borkenRule = supplier.GetBrokenRules()[0];
                return this.ResultValue(Int32.Parse(borkenRule.Name), false, borkenRule.Description);
            }
            return this.ResultValue(data: true);
        }
    }
}
