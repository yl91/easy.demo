using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Application.Application.Supplier.Add
{
    public class H5AddReturnTransformer : H5AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            return this.ResultValue(data: "h5");
        }
    }
}
