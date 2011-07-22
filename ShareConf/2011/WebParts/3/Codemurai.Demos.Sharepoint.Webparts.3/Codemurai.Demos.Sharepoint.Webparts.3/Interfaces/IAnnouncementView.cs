using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Interfaces
{
    public interface IAnnouncementView
    {
        void SetDataSource(IEnumerable<AnnouncementViewModel> viewModel);
    }
}