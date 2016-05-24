using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Application.Application.Supplier.RemoveAll
{
    class RemoveAllReturnTransformer : AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            return this.ResultValue(data: true);
        }
    }
}
