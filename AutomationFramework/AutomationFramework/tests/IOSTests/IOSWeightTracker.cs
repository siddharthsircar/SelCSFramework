﻿using AutomationFramework.Framework;
using AutomationFramework.Pages.IOSPages.Dashboard;
using AutomationFramework.Pages.IOSPages.Login;
using AutomationFramework.Pages.IOSPages.MyProfile;
using AutomationFramework.Pages.IOSPages.Trackers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AutomationFramework.Tests.IOSTests
{
    /// <summary>
    /// Mobile Weight Tracker Test Class
    /// </summary>
    [TestFixture]
    public class IOSWeightTracker : Base
    {
        String pageName;

        /// <summary>
        /// The constructor will calculate current class name
        /// Which will be used by ElementLocator to get 'By' object.
        /// Our repository (Or_Mob.xml) contains locators of each page which will be differentiated by classname
        /// </summary>
        public IOSWeightTracker()
        {
            pageName = this.GetType().Name;
            Console.WriteLine("Current class : " + pageName);
        }

        /// <summary>
        /// TestCase: Verify Weight Tracker page UI
        /// </summary>
        [Test]
        [Order(1)]
        public void TC_VerifyWeightTrackerUIElements()
        {
            // Skip Intro
            Page_ISkipIntro skipIntro = new Page_ISkipIntro();
            skipIntro.ClickSkipIntro();

            // Perform Login
            Page_ILogin plogin = new Page_ILogin();
            plogin.moblogin();

            // Close all Overlays (Popups)
            Page_IDashboard dashboard = new Page_IDashboard();
            dashboard.CloseAllDashboardOverlays();

            //Navigate to Tracker Home Page
            Page_IProfile trcker = new Page_IProfile();
            trcker.NavigateToTrackerHomePage();

            //Navigate to Weight Tracker
            CommonTrackers ct = new CommonTrackers(softassertions);
            ct.NavigateToTracker("Weight");

            //Validate Page UI Elements            
            //List<string[]> uielements = CSVReaderDataTable.GetCSVData("MobileTrackerData", pageName, "uielements");
            //ct.ValidatePageUI(uielements, "Page_MWeightTracker");
            //softassertions.AssertAll();
        }

        /// <summary>
        /// TestCase: Verify Weight Tracker
        /// </summary>
        [Test]
        [Order(2)]
        public void TC_VerifyWeightTracker()
        {
            // Enter Tracker value and Update
            List<string[]> trackerdata = CSVReaderDataTable.GetCSVData("MobileInputData", pageName, "weightdata");
            Page_IWeightTracker weightTracker = new Page_IWeightTracker(softassertions);
            weightTracker.UpdateWeightTracker(trackerdata);

            // Verify Tracker History
            List<string[]> trackerhistory = CSVReaderDataTable.GetCSVData("MobileTrackerData", pageName, "trackerhistory");
            TestContext.WriteLine("trackerhistory count" + trackerhistory.Count);
            weightTracker.VerifyTrackerHistory(trackerhistory);
            softassertions.AssertAll();
        }        
    }
}
