using Codemurai.Demos.Sharepoint.Webparts._4.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._4.Model;
using StructureMap.Configuration.DSL;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Infrastructure
{
    public class SPRegistry : Registry
    {
        public SPRegistry()
        {
            For<IAnnouncementService>().Use<SPAnnouncementService>();
        }
    }
}