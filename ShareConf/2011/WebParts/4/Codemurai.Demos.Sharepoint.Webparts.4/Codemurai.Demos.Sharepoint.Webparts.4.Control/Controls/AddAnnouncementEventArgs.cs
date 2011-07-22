using System;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls
{
    public class AddAnnouncementEventArgs : EventArgs
    {
        private readonly string _title;
        private readonly string _body;
        private readonly string _expireDate;

        public AddAnnouncementEventArgs(string title, string body, string expireDate)
        {
            _title = title;
            _body = body;
            _expireDate = expireDate;
        }

        public string ExpireDate
        {
            get { return _expireDate; }
        }

        public string Body
        {
            get { return _body; }
        }

        public string Title
        {
            get { return _title; }
        }
    }
}