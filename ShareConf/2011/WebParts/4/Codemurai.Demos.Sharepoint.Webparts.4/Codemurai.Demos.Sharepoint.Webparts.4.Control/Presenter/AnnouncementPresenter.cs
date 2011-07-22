using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.View;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;
using Codemurai.Demos.Sharepoint.Webparts._4.Dto;
using Codemurai.Demos.Sharepoint.Webparts._4.Interfaces;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.Presenter
{
    public class AnnouncementPresenter : BasePresenter<IAnnouncementView>
    {
        private readonly IAnnouncementService _model;
        private readonly IAnnouncementView _view;
        private IEnumerable<AnnouncementDto> _announcementDtos;

        public AnnouncementPresenter(IAnnouncementView view, IAnnouncementService model) : base(view)
        {
            _view = view;
            _model = model;
        }


        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            View.AddClicked += ViewAddClicked;
        }

        private void ViewAddClicked(object sender, AddAnnouncementEventArgs e)
        {
            DateTime? expires = ConvertExpiresStringToDate(e.ExpireDate);
            _model.SaveAnnouncement(new AnnouncementDto(e.Title, e.Body, expires));
        }

        protected override void GetModel()
        {
            _announcementDtos = _model.GetAnnouncements();
        }

        protected override void BindView()
        {
            base.BindView();

            _view.SetDataSource(ConvertDtoToViewModel(_announcementDtos));
        }

        private static IEnumerable<AnnouncementViewModel> ConvertDtoToViewModel(
            IEnumerable<AnnouncementDto> announcementDtos)
        {
            return announcementDtos.Select(
                x => new AnnouncementViewModel(x.Body, x.Title, x.Expires));
        }

        private static DateTime? ConvertExpiresStringToDate(string expires)
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
    }
}