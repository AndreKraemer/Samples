using System.Collections.Generic;
using System.Web.UI;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.Controls
{
    public class AnnouncementTableRenderer
    {
        private readonly IEnumerable<AnnouncementViewModel> _viewModel;

        public AnnouncementTableRenderer(IEnumerable<AnnouncementViewModel> viewModel)
        {
            _viewModel = viewModel;
        }

        public void RenderTable(HtmlTextWriter writer)
        {
            writer.Write(RenderTable());
        }

        public string RenderTable()
        {
            string table = "<table>";
            table += "<thead><tr><th>Titel</th><th>Beschreibung</th><th>Ablaufdatum</th></tr></thead>";
            table += "<tbody>";
            foreach (var announcement in _viewModel)
            {
                var css = announcement.IsExpired ? " style = 'color: red'" : string.Empty;
                
                table += "<tr" + css + ">";
                table += "<td>";
                table += announcement.Title;
                table += "</td>";
                table += "<td>";
                table += announcement.ShortendBody;
                table += "</td>";
                table += "<td>";
                if (announcement.Expires.HasValue)
                {
                    table += announcement.Expires.Value.ToShortDateString();
                }
                table += "</td>";

                table += "</tr>";
            }
            table += "</tbody>";
            table += "<table>";

            return table;
        }
    }
}