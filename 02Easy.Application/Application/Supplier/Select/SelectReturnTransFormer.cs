using System.Net.Sockets;
using Easy.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Models.Supplier;
using M = Easy.Domain.Model;

namespace Easy.Application.Application.Supplier.Select
{
    public class SelectReturnTransFormer:AppReturnTransFormer
    {
        public override dynamic GetValue(Domain.Application.ReturnContext context, object data)
        {
            PageList<M.Supplier> page = data as PageList<M.Supplier>;
            List<SelectModel> list = page.Collections.Select(m => new SelectModel() { Id = m.Id,Address = m.Address,BusinessStatus = m.BusinessStatus.GetHashCode(),DeliveryStatus = m.CurrentDeliveryStatus,Name = m.Name,Tel=m.Tel}).ToList();



            return this.ResultValue(data: new PageList<SelectModel>()
            {
                TotalRows = page.TotalRows,
                
                Collections =list
            });

        }
    }
}
 