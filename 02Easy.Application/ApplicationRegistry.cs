using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Application;
using Easy.Application.Application.Demo;
using Easy.Application.Application.Supplier;
using Easy.Domain.Application;

namespace Easy.Application
{
    /// <summary>
    /// 应用服务注册中心
    /// </summary>
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new SupplierApplication());
            ApplicationFactory.Instance().Register(new DemoApplication());
        }

        public static SupplierApplication Supplier
        {
            get
            {
                return ApplicationFactory.Instance().Get<SupplierApplication>();
            }
        }

        public static DemoApplication Demo
        {
            get { return ApplicationFactory.Instance().Get<DemoApplication>(); }
        }
    }
}
