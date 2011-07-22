using System;
using System.Linq;
using Codemurai.Demos.Sharepoint.Webparts._3.Presenter;
using Codemurai.Demos.Sharepoint.Webparts._3.Tests.Fakes;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Tests
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
            presenter.BindView();

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
            presenter.SaveAnnouncement(viewModel);

            // Assert
            Assert.AreEqual(viewModel.Title, fakeService.SavedDto.Title);
            Assert.AreEqual(viewModel.Body, fakeService.SavedDto.Body);
            Assert.AreEqual(viewModel.Expires, fakeService.SavedDto.Expires);

        }



    }
}