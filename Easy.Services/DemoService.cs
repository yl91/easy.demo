using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.ServiceFramework;
using Easy.Public.HttpRequestService;
using Easy.Rpc;
using Easy.Rpc.Cluster;
using Easy.Rpc.LoadBalance;

namespace Easy.Services
{
    public class DemoService : IDemoService, IService
    {
        [ServiceProtocol]
        [Directory("EasyDemo", "Demo/SayHello")]
        [Cluster(FailoverCluster.NAME)]
        [LoadBalance(RandomLoadBalance.NAME)]
        public virtual ResultWithData<string> SayHello(string name, int age, InvokerContext context = null)
        {
            var actualContext = context as ServiceInvokerContext;

            var foodInvoker = new DemoInvoker<ResultWithData<string>>((invoker, node, path) =>
            {
                string url = invoker.JoinURL(node, path)+"?name="+name+"&age="+age;
                var request = HttpRequestClient.Request(url, "GET", false);
                request.Headers.Add("SystemId", actualContext.SystemId);
                request.Headers.Add("Version", actualContext.Version);
                return request.Send()
                    .GetBodyContent<ResultWithData<string>>(close: true);

            });
            return ClientInvoker.Invoke(foodInvoker, context);
        }
    }

    class DemoInvoker<T> : BaseInvoker<T>
    {
        public DemoInvoker(Func<BaseInvoker<T>, Node, string, T> func)
            : base(func)
        {

        }
        public override string JoinURL(Node node, string path)
        {
            return node.Url.Trim() + path.Trim();
        }
    }
}
