using System.ComponentModel;
using Easy.Application.Models;
using Easy.Application.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = Easy.Domain.Model;

namespace Easy.Application.Application.Supplier.GetById
{
    public class GetByIdReturnTransformer:AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            var model= data as M.Supplier;

            if (model==null)
            {
                return new ResultWithData<DetailSupplierModel>(ResultStatus.Error.GetHashCode(), null, "餐厅不存在");
            }

            return new ResultWithData<DetailSupplierModel>(ResultStatus.Ok.GetHashCode(), model.ToDetailSupplierModel());
        }
    }
}
