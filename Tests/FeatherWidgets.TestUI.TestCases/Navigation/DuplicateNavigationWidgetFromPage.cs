﻿using Feather.Widgets.TestUI.Framework;
using FeatherWidgets.TestUI.TestCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatherWidgets.TestUI
{
    /// <summary>
    /// This is a sample test class.
    /// </summary>
    [TestClass]
    public class DuplicateNavigationWidgetFromPage_ : FeatherTestCase
    {
        // <summary>
        /// Pefroms Server Setup and prepare the system with needed data.
        /// </summary>
        protected override void ServerSetup()
        {
            BAT.Macros().User().EnsureAdminLoggedIn();
            BAT.Arrange(this.TestName).ExecuteSetUp();
        }

        /// <summary>
        /// Performs clean up and clears all data created by the test.
        /// </summary>
        protected override void ServerCleanup()
        {
            BAT.Arrange(this.TestName).ExecuteTearDown();
        }

        [TestMethod,
       Microsoft.VisualStudio.TestTools.UnitTesting.Owner("Feather team"),
       TestCategory(FeatherTestCategories.PagesAndContent)]
        public void DuplicateNavigationWidgetFromPage()
        {
            BAT.Macros().NavigateTo().Pages();
            BAT.Wrappers().Backend().Pages().PagesWrapper().OpenPageZoneEditor(PageName);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().AddWidget(WidgetName);
            BAT.Wrappers().Backend().Pages().PageZoneEditorWrapper().SelectExtraOptionForWidget(OperationName);
            BAT.Wrappers().Backend().Pages().PageZoneEditorWrapper().PublishPage();
            this.VerifyNavigationOnTheFrontend();
        }

        public void VerifyNavigationOnTheFrontend()
        {
            string[] parentPages = new string[] { PageName };

            BAT.Macros().NavigateTo().CustomPage("~/" + PageName.ToLower());
            ActiveBrowser.WaitUntilReady();

            BATFeather.Wrappers().Frontend().Navigation().NavigationWrapper().VerifyNavigationCountOnThePageFrontend(ExpectedCount);
            BATFeather.Wrappers().Frontend().Navigation().NavigationWrapper().VerifyNavigationOnThePageFrontend(NavTemplateClass, parentPages);
        }

        private const string PageName = "ParentPage";
        private const string WidgetName = "Navigation";
        private const string OperationName = "Duplicate";
        private const string NavTemplateClass = "nav navbar-nav";
        private const int ExpectedCount = 2;
    }
}
