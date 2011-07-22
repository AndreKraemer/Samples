using System;
using System.Linq;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.Presenter;
using Codemurai.Demos.Sharepoint.Webparts._4.Control.ViewModel;
using Codemurai.Demos.Sharepoint.Webparts._4.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codemurai.Demos.Sharepoint.Webparts._4.Tests
{
    [TestClass]
    public class When_Using_An_AnnouncementPresenter
    {

        [TestMethod]
        public void It_Should_Bind_Valid_Data_To_The_View()
        {

            // Arrange
            var fakeView = new FakeAnnouncementView();
            var fakeService = new FakeAnnouncementService();
            var presenter = new AnnouncementPresenter(fakeView, fakeService);

            // Act
            fakeView.InvokeViewInitialized(false);
            fakeView.InvokeViewLoaded(false);

            // Assert
            Assert.AreEqual(fakeService.GetAnnouncements().Count(), fakeView.ViewModel.Count());

            foreach (var announcementDto in fakeService.GetAnnouncements())
            {
                Assert.IsTrue(fakeView.ViewModel.Any(x => x.Title == announcementDto.Title));
            }
        }

        [TestMethod]
        public void It_Should_Save_Data_To_The_Model()
        {
            // Arrange
            var fakeView = new FakeAnnouncementView();
            var fakeService = new FakeAnnouncementService();
            var presenter = new AnnouncementPresenter(fakeView, fakeService);

            var viewModel = new AnnouncementViewModel("Body", "Title", DateTime.Now);

            // Act
            fakeView.InvokeViewInitialized(false);
            fakeView.InvokeViewLoaded(false);
            fakeView.InvokeAddClicked(viewModel.Title, viewModel.Body, viewModel.Expires.Value.ToString() );

            // Assert
            Assert.AreEqual(viewModel.Title, fakeService.SavedDto.Title);
            Assert.AreEqual(viewModel.Body, fakeService.SavedDto.Body);

        }



    }
}