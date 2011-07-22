using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Codemurai.Demos.Sharepoint.Webparts._3.Controls;
using Codemurai.Demos.Sharepoint.Webparts._3.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._3.Model;
using Codemurai.Demos.Sharepoint.Webparts._3.Presenter;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._3.View.Announcements3
{
    [ToolboxItem(false)]
    public class Announcements3 : WebPart, IAnnouncementView
    {
        private IEnumerable<AnnouncementViewModel> _announcements;
        private AnnouncementPresenter _presenter;
        protected AnnouncementControl AnnouncementControl;

        #region IAnnouncementView Members

        public void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel)
        {
            _announcements = viewModel;
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CreatePresenter();
        }

        private void CreatePresenter()
        {
            _presenter = new AnnouncementPresenter(this, new AnnouncementService());
        }

        protected override void CreateChildControls()
        {
            AnnouncementControl = new AnnouncementControl();
            AnnouncementControl.AddClicked += new EventHandler<AddAnnouncementEventArgs>(AnnouncementControlAddClicked);
            Controls.Add(AnnouncementControl);
        }

        void AnnouncementControlAddClicked(object sender, AddAnnouncementEventArgs e)
        {
            _presenter.SaveAnnouncement(new AnnouncementViewModel(e.Body,e.Title,e.ExpireDate));
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            RenderChildren(writer);
            _presenter.BindView();
            var renderer = new AnnouncementTableRenderer(_announcements);
            renderer.RenderTable(writer);
        }
    }
}