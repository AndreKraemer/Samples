using System;
using System.Collections.Generic;
using System.Web.UI;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Presenter;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;
using StructureMap;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.View
{
    public class Announcement4 : BaseView, IAnnouncementView
    {

        private IEnumerable<AnnouncementViewModel> _announcements;
        protected AnnouncementControl announcementControl;

        #region IAnnouncementView Members

        public void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel)
        {
            _announcements = viewModel;
        }

        #endregion


        protected override void CreatePresenter()
        {
            ObjectFactory.With<IAnnouncementView>(this).GetInstance<AnnouncementPresenter>();
        }

        protected override void CreateChildControls()
        {
            announcementControl = new AnnouncementControl();
            Controls.Add(announcementControl);
            announcementControl.AddClicked += AnnouncementControlAddClicked;
        }

        protected void AnnouncementControlAddClicked(object sender, AddAnnouncementEventArgs e)
        {
            InvokeAddClicked(e);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            RenderChildren(writer);
            var renderer = new AnnouncementTableRenderer(_announcements);
            renderer.RenderTable(writer);
        }


        public event EventHandler<AddAnnouncementEventArgs> AddClicked;

        public void InvokeAddClicked(AddAnnouncementEventArgs e)
        {
            EventHandler<AddAnnouncementEventArgs> handler = AddClicked;
            if (handler != null) handler(this, e);
        }
    }
}