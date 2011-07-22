using System;
using System.Web.UI.WebControls.WebParts;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.View
{
    public abstract class BaseView : WebPart, IView
    {
        public event EventHandler<ViewEventArgs> ViewInitialized;
        public event EventHandler<ViewEventArgs> ViewLoaded;
        protected BaseView()
        {
            Init += BaseViewInit;
            Load += BaseViewLoad;
            PreRender += BaseViewPreRender;
        }


        protected void BaseViewInit(object sender, EventArgs e)
        {
            CreatePresenter();

        }

        protected void BaseViewLoad(object sender, EventArgs e)
        {
            if (ViewInitialized != null)
            {
                ViewInitialized(this, new ViewEventArgs(Page.IsPostBack));
            }
        }


        void BaseViewPreRender(object sender, EventArgs e)
        {
            if (ViewLoaded != null)
            {
                ViewLoaded(this, new ViewEventArgs(Page.IsPostBack));
            }
        }

        protected abstract void CreatePresenter();


    }
}