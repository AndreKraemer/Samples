using System;
using System.Data;
using Microsoft.SharePoint;

namespace Codemurai.Demos.Sharepoint.Webparts._2.Model
{
    public class AnnouncementService
    {
        public DataTable GetAnnouncements()
        {
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];
            var announcements = announcementsList.Items;
            return announcements.GetDataTable();

        }

        public void SaveAnnouncement(string Title, string Body, DateTime? Expires)
        {
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];

            SPItem announcement = announcementsList.AddItem();
            announcement["Title"] = Title;
            announcement["Body"] = Body;
            announcement["Expires"] = Expires;
            announcement.Update();
        }

    }
}