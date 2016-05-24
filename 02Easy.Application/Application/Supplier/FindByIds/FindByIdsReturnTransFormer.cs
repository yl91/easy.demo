using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Models.Supplier;
using M = Easy.Domain.Model;

namespace Easy.Application.Application.Supplier.FindByIds
{
    public class FindByIdsReturnTransFormer:AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            var list= data as List<M.Supplier>;

            return this.ResultValue(data:list.Select(m=>m.ToDetailSupplierModel()));
        }
    }
}
