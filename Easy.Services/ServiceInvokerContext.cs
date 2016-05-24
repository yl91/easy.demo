using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Rpc;

namespace Easy.Services
{
    public class ServiceInvokerContext : InvokerContext
    {
        public ServiceInvokerContext(DirectoryContext directoryContext, ClusterContext clusterContext, LoadBalanceContext loadBalanceContext,string systemId,string version):base(directoryContext,clusterContext,loadBalanceContext)
        {
            this.SystemId = systemId;
            this.Version = version;
        }

        public string SystemId { get; set; }
        public string  Version { get; set; } 
    }
}
