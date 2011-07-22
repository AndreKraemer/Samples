using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._4.Dto;
using Codemurai.Demos.Sharepoint.Webparts._4.Interfaces;

namespace WebDemo.Model
{
    public class WebAnnouncementService : IAnnouncementService
    {
        private static IList<AnnouncementDto> announcements = new List<AnnouncementDto>();

        public IEnumerable<AnnouncementDto> GetAnnouncements()
        {
            return announcements;
        }

        public void SaveAnnouncement(AnnouncementDto value)
        {
            announcements.Add(value);
        }
    }
}