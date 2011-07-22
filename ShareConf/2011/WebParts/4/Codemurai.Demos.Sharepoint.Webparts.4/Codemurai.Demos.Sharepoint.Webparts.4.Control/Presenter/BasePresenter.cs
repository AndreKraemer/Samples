using System;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.View;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Control.Presenter
{
    public abstract class BasePresenter<TView> where TView: IView
    {
        protected BasePresenter(TView view)
        {
            View = view;
            View.ViewInitialized += ViewInitialized;
            View.ViewLoaded += ViewLoaded;
        }

        void ViewInitialized(object sender, ViewEventArgs e)
        {
            SubscribeEvents();
            LayoutView();
        }

        private void ViewLoaded(object sender, ViewEventArgs e)
        {
            GetModel();
            BindView();
        }

        protected virtual void SubscribeEvents()
        {
        }

        protected virtual void LayoutView()
        {
        }

        protected virtual void GetModel()
        {
        }

        protected virtual void BindView()
        {
        }

        public TView View { get; internal set; }
    }
}