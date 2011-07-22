using System;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Tests
{
    [TestClass]
    public class When_Using_An_AnnouncementViewModel
    {
        [TestMethod]
        public void It_Should_Expire_PastExpireDates()
        {
            var viewModel = new AnnouncementViewModel("Body", "Title", DateTime.Now.AddDays(-1));

            Assert.IsTrue(viewModel.IsExpired);

        }

        [TestMethod]
        public void It_Should_Not_Expire_FutureExpireDates()
        {
            var viewModel = new AnnouncementViewModel("Body", "Title", DateTime.Now.AddDays(1));

            Assert.IsFalse(viewModel.IsExpired);

        }

        [TestMethod]
        public void It__Should_Shorten_Long_Body_Strings_To_40_Characters()
        {

            string body = "01234567890123456789012345678901234567890123456789";
            var viewModel = new AnnouncementViewModel(body, "Title", DateTime.Now.AddDays(1));
            string expected = "0123456789012345678901234567890123456...";

            Assert.AreEqual(expected, viewModel.ShortendBody);

        }


        [TestMethod]
        public void It_Should_Not_Shorten_Short_Body_Strings()
        {

            string body = "0123456789";
            var viewModel = new AnnouncementViewModel(body, "Title", DateTime.Now.AddDays(1));
            string expected = "0123456789";

            Assert.AreEqual(expected, viewModel.ShortendBody);

        }
    }
}