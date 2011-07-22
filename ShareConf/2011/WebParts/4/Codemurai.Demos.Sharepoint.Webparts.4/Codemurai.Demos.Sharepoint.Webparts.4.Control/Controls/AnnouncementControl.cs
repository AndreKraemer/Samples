using System;
using System.Web.UI.WebControls;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls
{
    public class AnnouncementControl : CompositeControl
    {
        public event EventHandler<AddAnnouncementEventArgs> AddClicked;
        protected Label TitleLabel;
        protected TextBox TitleTextBox;
        protected Label BodyLabel;
        protected TextBox BodyTextArea;
        protected Button AddButton;
        protected Label ExpireLabel;
        protected TextBox ExpireTextBox;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
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
            
            this.Controls.Add(AddButton);
            AddButton.ID = "AddButton";
            AddButton.Click += AddButtonClick;
            ChildControlsCreated = true;
        }

        protected void AddButtonClick(object sender, EventArgs e)
        {
            var handler = AddClicked;
            if(handler != null)
            {
                handler(this, new AddAnnouncementEventArgs(TitleTextBox.Text, BodyTextArea.Text, ExpireTextBox.Text));
            }
        }

        public void ClearFields()
        {
            EnsureChildControls();
            TitleTextBox.Text = string.Empty;
            BodyTextArea.Text = string.Empty;
            ExpireTextBox.Text = string.Empty;
        }

    }
}