using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._3.Dto;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Interfaces
{
    public interface IAnnouncementService
    {
        IEnumerable<AnnouncementDto> GetAnnouncements();
        void SaveAnnouncement(AnnouncementDto value);
    }
}