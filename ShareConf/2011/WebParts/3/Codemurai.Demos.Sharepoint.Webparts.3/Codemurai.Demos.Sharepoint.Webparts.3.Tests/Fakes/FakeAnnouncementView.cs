using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._3.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Tests.Fakes
{
    public class FakeAnnouncementView : IAnnouncementView
    {
        public void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel)
        {
            this.ViewModel = viewModel;
        }

        public IEnumerable<AnnouncementViewModel> ViewModel { get; private set; }
    }
}