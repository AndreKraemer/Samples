using System;
using System.Collections.Generic;
using Codemurai.Demos.Sharepoint.Webparts._3.Controls;
using Codemurai.Demos.Sharepoint.Webparts._3.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codemurai.Demos.Sharepoint.Webparts._3.Tests
{
    [TestClass]
    public class When_Using_An_AnnouncementTable_Renderer
    {


        [TestMethod]
        public void It_Should_Render_A_Valid_Table()
        {
            // Arrange
            var list = new List<AnnouncementViewModel>();
            list.Add(new AnnouncementViewModel("body 1", "title 1", new DateTime(2045, 10, 02)));
            list.Add(new AnnouncementViewModel("body 2", "title 2", new DateTime(2045, 10, 02)));

            var renderer = new AnnouncementTableRenderer(list);

            var expected = "<table><thead><tr><th>Titel</th><th>Beschreibung</th><th>Ablaufdatum</th></tr></thead><tbody><tr><td>title 1</td><td>body 1</td><td>02.10.2045</td></tr><tr><td>title 2</td><td>body 2</td><td>02.10.2045</td></tr></tbody><table>";
            // Act
            var actual = renderer.RenderTable();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void It_Should_Render_A_Red_Line_For_An_Expired_Entry()
        {
            // Arrange
            var list = new List<AnnouncementViewModel>();
            list.Add(new AnnouncementViewModel("body 1", "title 1", new DateTime(2000, 10, 02)));
            list.Add(new AnnouncementViewModel("body 2", "title 2", new DateTime(2045, 10, 02)));

            var renderer = new AnnouncementTableRenderer(list);

            var expected = "<table><thead><tr><th>Titel</th><th>Beschreibung</th><th>Ablaufdatum</th></tr></thead><tbody><tr style = 'color: red'><td>title 1</td><td>body 1</td><td>02.10.2000</td></tr><tr><td>title 2</td><td>body 2</td><td>02.10.2045</td></tr></tbody><table>";
            // Act
            var actual = renderer.RenderTable();

            Assert.AreEqual(expected, actual);

        }
    }
}