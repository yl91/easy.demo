﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Models;
using M = Easy.Domain.Model;

namespace Easy.Application.Application.Supplier.Open
{
    public class OpenReturnTransFormer:AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            var supplier = data as M.Supplier;
            if (supplier == null)
            {
                return new Result(ResultStatus.Error.GetHashCode(), "餐厅不存在");
                
            }

            if (supplier.GetBrokenRules().Count > 0)
            {
                return new Result(ResultStatus.Error.GetHashCode(), supplier.GetBrokenRules()[0].Description);
            }

            return this.ResultValue(data: true);
        }
    }
}
