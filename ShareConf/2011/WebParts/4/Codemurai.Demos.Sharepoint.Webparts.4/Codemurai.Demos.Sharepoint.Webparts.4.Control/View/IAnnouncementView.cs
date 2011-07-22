using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.View
{
    public interface IAnnouncementView : IView
    {
        void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel);
        event EventHandler<AddAnnouncementEventArgs> AddClicked;
    }
}