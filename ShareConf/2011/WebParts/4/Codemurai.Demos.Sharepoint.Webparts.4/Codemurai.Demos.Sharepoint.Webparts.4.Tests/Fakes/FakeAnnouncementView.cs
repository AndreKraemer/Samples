using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.View;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;


namespace Codemurai.Demos.Sharepoint.Webparts._4.Tests.Fakes
{
    public class FakeAnnouncementView : IAnnouncementView
    {
        public void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler<AddAnnouncementEventArgs> AddClicked;

        public void InvokeAddClicked(string title, string body, string expires)
        {
            EventHandler<AddAnnouncementEventArgs> handler = AddClicked;
            if (handler != null) handler(this, new AddAnnouncementEventArgs(title, body, expires ));
        }

        public IEnumerable<AnnouncementViewModel> ViewModel { get; private set; }
        public event EventHandler<ViewEventArgs> ViewInitialized;

        public void InvokeViewInitialized(bool isPostBack)
        {
            EventHandler<ViewEventArgs> handler = ViewInitialized;
            if (handler != null) handler(this, new ViewEventArgs(isPostBack));
        }

        public event EventHandler<ViewEventArgs> ViewLoaded;

        public void InvokeViewLoaded(bool isPostback)
        {
            EventHandler<ViewEventArgs> handler = ViewLoaded;
            if (handler != null) handler(this, new ViewEventArgs(isPostback));
        }
    }
}