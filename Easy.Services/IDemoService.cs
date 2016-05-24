using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Rpc;

namespace Easy.Services
{
    public interface IDemoService
    {
        ResultWithData<string> SayHello(string name, int age, InvokerContext context=null);
    }
}
