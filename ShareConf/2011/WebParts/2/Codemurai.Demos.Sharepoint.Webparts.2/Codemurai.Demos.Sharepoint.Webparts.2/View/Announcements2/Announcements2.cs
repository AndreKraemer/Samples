using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Codemurai.Demos.Sharepoint.Webparts._2.Interfaces;
using Codemurai.Demos.Sharepoint.Webparts._2.Presenter;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Codemurai.Demos.Sharepoint.Webparts._2.View.Announcements2
{
    [ToolboxItemAttribute(false)]
    public class Announcements2 : WebPart, IAnnouncementView
    {
        protected Label TitleLabel;
        protected TextBox TitleTextBox;
        protected Label BodyLabel;
        protected TextBox BodyTextArea;
        protected Button AddButton;
        protected Label ExpireLabel;
        protected TextBox ExpireTextBox;
        protected AnnouncementPresenter _presenter;
        private DataTable _announcementsTable;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _presenter = new AnnouncementPresenter(this);
        }

        protected override void CreateChildControls()
        {
            TitleLabel = new Label();
            TitleLabel.Text = "Titel";
            this.Controls.Add(TitleLabel);

            TitleTextBox = new TextBox();
            this.Controls.Add(TitleTextBox);

            BodyLabel = new Label();
            BodyLabel.Text = "Text";
            this.Controls.Add(BodyLabel);

            BodyTextArea = new TextBox();
            BodyTextArea.TextMode = TextBoxMode.MultiLine;
            this.Controls.Add(BodyTextArea);

            ExpireLabel = new Label();
            ExpireLabel.Text = "Ablaufdatum";
            this.Controls.Add(ExpireLabel);

            ExpireTextBox = new TextBox();
            this.Controls.Add(ExpireTextBox);

            AddButton = new Button();
            AddButton.Text = "Hinzufügen";
            AddButton.Click += AddButton_Click;
            this.Controls.Add(AddButton);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            DateTime? expireDate;

            if (string.IsNullOrEmpty(ExpireTextBox.Text))
            {
                expireDate = null;
            }
            else
            {
                expireDate = Convert.ToDateTime(ExpireTextBox.Text, CultureInfo.CurrentUICulture);
            }

            _presenter.SaveAnnouncement(TitleTextBox.Text, BodyTextArea.Text, expireDate);

        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            RenderChildren(writer);
            _presenter.BindView();

            if(_announcementsTable == null)
            {
                return;
            }
            string table = "<table>";
            table += "<thead><tr><th>Titel</th><th>Beschreibung</th><th>Ablaufdatum</th></tr></thead>";
            table += "<tbody>";
            foreach (DataRow announcement in _announcementsTable.Rows)
            {
                bool isExpired = false;
                DateTime expires;
                if (announcement["Expires"] != DBNull.Value)
                {
                    expires = (DateTime)announcement["Expires"];
                    isExpired = expires < DateTime.Now;
                }
                else
                {
                    expires = DateTime.MinValue;
                }
                string css = string.Empty;
                if (isExpired)
                {
                    css = " style = 'color: red' ";
                }
                table += "<tr" + css + ">";
                table += "<td>";
                table += announcement["Title"].ToString();
                table += "</td>";
                table += "<td>";
                string body = StripTags(announcement["Body"].ToString());
                if (body.Length > 40)
                {
                    body = body.Substring(0, 37) + "...";
                }
                table += body;
                table += "</td>";
                table += "<td>";
                if (expires != DateTime.MinValue)
                {
                    table += expires.ToShortDateString();
                }
                table += "</td>";

                table += "</tr>";
            }

            table += "</tbody>";
            table += "<table>";
            writer.Write(table);
        }

        public void SetDataSource(DataTable table)
        {
            _announcementsTable = table;
        }

        private static string StripTags(string html)
        {
            string text = Regex.Replace(html, "<[^>]*>", "");
            return text;
        }
    }
}
