using System.Web;
using Codemurai.Demos.Sharepoint.Webparts._4.Infrastructure;
using StructureMap;

namespace Codemurai.Demos.Sharepoint.Webparts._4.HttpModules
{
    public class StructureMapRegistrationModule : IHttpModule
    {
        private static bool _isInitialized = false;
        private static readonly object SyncRoot = new object();

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            if (!_isInitialized)
            {
                lock (SyncRoot)
                {
                    if (!_isInitialized)
                    {
                        ObjectFactory.Initialize(x =>
                        {
                            x.AddRegistry<SPRegistry>();
                        });

                        _isInitialized = true;
                    }
                }
            }
        }

        
    }
}