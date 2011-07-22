using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._4.Dto;
using Codemurai.Demos.Sharepoint.Webparts._4.Interfaces;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Tests.Fakes
{
    public class FakeAnnouncementService : IAnnouncementService
    {
        public IEnumerable<AnnouncementDto> GetAnnouncements()
        {
            for (int i = 0; i < 5; i++)
            {
                string title = string.Format("Title {0}", i);
                string body = string.Format("Body -{0}- 0123456789012345678901234567890123456789",i);
                yield return new AnnouncementDto(title, body, DateTime.Now);
            }
        }

        public void SaveAnnouncement(AnnouncementDto value)
        {
            SavedDto = value;
        }

        public AnnouncementDto SavedDto { get; private set; }
    }
}