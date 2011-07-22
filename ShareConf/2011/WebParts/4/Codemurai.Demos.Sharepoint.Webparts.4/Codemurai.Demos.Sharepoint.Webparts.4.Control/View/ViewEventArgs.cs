using System;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.View
{
    public class ViewEventArgs : EventArgs
    {
        private readonly bool isPostBack;


        public ViewEventArgs(bool isPostBack)
        {
            this.isPostBack = isPostBack;
        }

        public bool IsPostBack { get { return this.isPostBack; } }

    }

}