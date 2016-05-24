using System;
using System.IO;
using System.Reflection;
using Easy.Domain.ServiceFramework;

namespace Easy.Services
{
    public static class ServicesRegistry
    {
        readonly static ServiceFactory factory;

        static ServicesRegistry()
        {
            ServiceFactoryBuilder b = new ServiceFactoryBuilder();
            string path = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory, "Easy.Services.dll");

            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("Easy.Services.services.xml");

            factory = b.Build(stream);
        }

        public static IDemoService Demo
        {
            get
            {
                return factory.Get<IDemoService>(); 
            }
        }
    }
}
