using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Easy.Domain.Model
{
    public static class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;

        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder builder = new RepositoryFactoryBuilder();
            factory = builder.Build(new System.IO.FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repositories.config")));
        }

        /// <summary>
        /// 餐厅 
        /// </summary>
        public static ISupplierRepository Supplier
        {
            get
            {
                return factory.Get<ISupplierRepository>();
            }
        }
    }
}
