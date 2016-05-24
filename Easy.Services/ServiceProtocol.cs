using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Rpc.Protocol;

namespace Easy.Services
{
    public class ServiceProtocol : DefaultProtocolAttribute
    {
        public override Type ContextType
        {
            get
            {
                return typeof (ServiceInvokerContext);
            }
        }
        public string SystemId
        {
            get
            {
                return  ConfigurationManager.AppSettings["SystemId"] ?? "DEFAULT";
            }
        }
        public string Version
        {
            get
            {
                return ConfigurationManager.AppSettings["Version"] ?? "";
                
            }
        }
    }
}
