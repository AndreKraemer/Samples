using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._4.Dto;
using Codemurai.Demos.Sharepoint.Webparts._4.Interfaces;
using Microsoft.SharePoint;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Data.SP.Model
{
    public class SPAnnouncementService : IAnnouncementService
    {
        public IEnumerable<AnnouncementDto> GetAnnouncements()
        {
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];
            var announcements = announcementsList.Items;
            foreach (SPItem announcement in announcements)
            {
                var expires = new DateTime?();
                if (announcement["Expires"] != null)
                {
                    expires = Convert.ToDateTime(announcement["Expires"]);
                }
                yield return new AnnouncementDto(announcement["Title"].ToString(),
                                                 announcement["Body"].ToString(),
                                                  expires);
            }

        }

        public void SaveAnnouncement(AnnouncementDto value)
        {
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];

            SPItem announcement = announcementsList.AddItem();
            announcement["Title"] = value.Title;
            announcement["Body"] = value.Body;
            announcement["Expires"] = value.Expires;
            announcement.Update();
        }
    }
}