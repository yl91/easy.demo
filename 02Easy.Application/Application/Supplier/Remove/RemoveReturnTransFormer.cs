using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Application.Application.Supplier.Remove
{
    public class RemoveReturnTransFormer:AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            return this.ResultValue<bool>(data: (bool)data);
        }
    }
}
