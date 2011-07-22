using System;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Dto
{
    public class AnnouncementDto
    {
        public AnnouncementDto(string title, string body, DateTime? expires)
        {
            Title = title;
            Body = body;
            Expires = expires;
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? Expires { get; set; }
    }
}