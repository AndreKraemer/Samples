using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Codemurai.Demos.Sharepoint.Webparts._3.ViewModel
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel(string body, string title, DateTime? expires)
        {
            Body = body;
            Title = title;
            Expires = expires;
        }


        public AnnouncementViewModel(string body, string title, string expires)
        {
            Body = body;
            Title = title;
            Expires = ConvertExpiresStringToDate(expires);
        }

        private DateTime? ConvertExpiresStringToDate(string expires)
        {
            DateTime? expireDate;

            if (string.IsNullOrEmpty(expires))
            {
                expireDate = null;
            }
            else
            {
                expireDate = Convert.ToDateTime(expires, CultureInfo.CurrentUICulture);
            }
            return expireDate;
        }

        public string Title { get; set; }

        public string Body { get; set; }

        public string ShortendBody
        {
            get { return ShortenString(StripTags(Body), 40); }
        }

        public DateTime? Expires { get; set; }

        public bool IsExpired
        {
            get
            {
                if (!Expires.HasValue)
                {
                    return false;
                }
                return Expires.Value < DateTime.Now;
            }
        }

        private static string StripTags(string html)
        {
            var text = Regex.Replace(html, "<[^>]*>", "");
            return text;
        }

        private static string ShortenString(string value, int length)
        {
            string result = value;
            if(!string.IsNullOrEmpty(value) && value.Length > length)
            {
                result = string.Format("{0}...", value.Substring(0, length - 3));
            }
            return result;
        }
    }
}