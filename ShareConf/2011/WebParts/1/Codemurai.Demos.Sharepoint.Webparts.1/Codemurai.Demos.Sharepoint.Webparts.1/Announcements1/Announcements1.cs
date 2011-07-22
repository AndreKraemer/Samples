using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace Codemurai.Demos.Sharepoint.Webparts._1.Announcements1
{
    [ToolboxItemAttribute(false)]
    public class Announcements1 : WebPart
    {
        protected Label TitleLabel;
        protected TextBox TitleTextBox;
        protected Label BodyLabel;
        protected TextBox BodyTextArea;
        protected Button AddButton;
        protected Label ExpireLabel;
        protected TextBox ExpireTextBox;

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

            ExpireLabel  = new Label();
            ExpireLabel.Text = "Ablaufdatum";
            this.Controls.Add(ExpireLabel);

            ExpireTextBox = new TextBox();
            this.Controls.Add(ExpireTextBox);

            AddButton = new Button();
            AddButton.Text = "Hinzufügen";
            AddButton.Click += AddButton_Click;
            this.Controls.Add(AddButton);

            
        }

        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            RenderChildren(writer);

            string table = "<table>";
            table += "<thead><tr><th>Titel</th><th>Beschreibung</th><th>Ablaufdatum</th></tr></thead>";
            table += "<tbody>";
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];
            var announcements = announcementsList.Items;
            foreach (SPItem announcement in announcements)
            {
                bool isExpired = false;
                DateTime expires;
                if(announcement["Expires"] != null)
                {
                    expires = (DateTime) announcement["Expires"];
                    isExpired = expires < DateTime.Now;
                }
                else
                {
                    expires = DateTime.MinValue;
                }
                string css = string.Empty;
                if(isExpired)
                {
                    css = " style = 'color: red' ";
                }
                table += "<tr" + css +">";
                table += "<td>";
                table += announcement["Title"].ToString();
                table += "</td>";
                table += "<td>";
                string body = StripTags(announcement["Body"].ToString());
                if(body.Length > 40)
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

        void AddButton_Click(object sender, EventArgs e)
        {
            var announcementsList = SPContext.Current.Site.RootWeb.Lists["Announcements"];
            


            SPItem announcement = announcementsList.AddItem();
            announcement["Title"] = TitleTextBox.Text;
            announcement["Body"] = BodyTextArea.Text;

            DateTime? expireDate;

            if (string.IsNullOrEmpty(ExpireTextBox.Text))
            {
                expireDate = null;
            }
            else
            {
                expireDate = Convert.ToDateTime(ExpireTextBox.Text, CultureInfo.CurrentUICulture);
            }

            announcement["Expires"] = expireDate;
            announcement.Update();
            
        }

        private static string StripTags(string html)
        {
            string text = Regex.Replace(html, "<[^>]*>", "");
            return text;
        }

    }
}
