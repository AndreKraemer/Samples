using System.Collections.Generic;
using System.Linq;
using Codemurai.Demos.Sharepoint.Webparts._3.Dto;
using Codemurai.Demos.Sharepoint.Webparts._3.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Presenter
{
    public class AnnouncementPresenter
    {
        private readonly IAnnouncementView _view;
        private readonly IAnnouncementService _model;

        public AnnouncementPresenter(IAnnouncementView view, IAnnouncementService model)
        {
            _view = view;
            _model = model;
        }


        public void SaveAnnouncement(AnnouncementViewModel viewModel)    
        {
            _model.SaveAnnouncement(new AnnouncementDto(viewModel.Title, viewModel.Body, viewModel.Expires));
        }

        public void BindView()
        {
            var announcementDtos = _model.GetAnnouncements(); 
            _view.SetDataSource(ConvertDtoToViewModel(announcementDtos));
        }

        static IEnumerable<AnnouncementViewModel> ConvertDtoToViewModel(IEnumerable<AnnouncementDto> announcementDtos)
        {
            return announcementDtos.Select(
                x => new AnnouncementViewModel(x.Body, x.Title, x.Expires));
        }
    }
}