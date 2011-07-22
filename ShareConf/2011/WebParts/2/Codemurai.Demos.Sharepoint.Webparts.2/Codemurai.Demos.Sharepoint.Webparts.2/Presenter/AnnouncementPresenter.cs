using System;
using Codemurai.Demos.Sharepoint.Webparts._2.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._2.Model;

namespace Codemurai.Demos.Sharepoint.Webparts._2.Presenter
{
    public class AnnouncementPresenter
    {
        private readonly IAnnouncementView _view;
        private readonly AnnouncementService _model;

        public AnnouncementPresenter(IAnnouncementView view)
        {
            _view = view;
            _model = new AnnouncementService();
        }

        public void SaveAnnouncement(string title, string body, DateTime? expires)
        {
            _model.SaveAnnouncement(title, body, expires);
        }

        public void BindView()
        {
            _view.SetDataSource(_model.GetAnnouncements());
        }

    }
}