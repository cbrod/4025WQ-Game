﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;

namespace UnitTests.Views.Game
{
    [TestFixture]
    public class AboutPageTests : AboutPage
    {
        App app;
        AboutPage page;

        // Base Constructor
        public AboutPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new AboutPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void AboutPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AboutPage_DatabaseSettingsSwitch_OnToggled_Default_Should_Pass()
        {
            // Arrange

            StackLayout frame = (StackLayout)page.FindByName("DatabaseSettingsFrame");
            var current = frame.IsVisible;

            ToggledEventArgs args = new ToggledEventArgs(current);


            // Act
            page.DatabaseSettingsSwitch_OnToggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_DebugSettingsSwitch_OnToggled_Default_Should_Pass()
        {
            // Arrange

            StackLayout frame = (StackLayout)page.FindByName("DebugSettingsFrame");
            var current = frame.IsVisible;

            ToggledEventArgs args = new ToggledEventArgs(current);


            // Act
            page.DebugSettingsSwitch_OnToggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }
    }
}
