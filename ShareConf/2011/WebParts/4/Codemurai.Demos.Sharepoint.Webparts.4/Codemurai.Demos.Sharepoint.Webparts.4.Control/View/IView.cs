using System;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.View
{

    public interface IView
    {
        event EventHandler<ViewEventArgs> ViewInitialized;
        event EventHandler<ViewEventArgs> ViewLoaded;
    }
}