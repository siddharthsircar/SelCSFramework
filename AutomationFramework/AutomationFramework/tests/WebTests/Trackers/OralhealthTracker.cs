﻿using AutomationFramework.Framework;
using AutomationFramework.Pages;
using AutomationFramework.Pages.WebPages.Trackers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests.WebTests.Trackers
{
    [TestFixture]
    [Order(26)]
    public class OralhealthTracker : Base
    {
        /// <summary>
        /// Test Case: Verifies Oral Health Tracker
        /// </summary>
        [Test, Order(1)]
        [Category("Regression")]
        [Category("AllClientReg")]
        public void TC_VerifyOralHealthTracker()
        {
            //To call the Page Login Method
            Page_Login plogin = new Page_Login();
            plogin.Login();
            Page_HAPrompt haprompt = new Page_HAPrompt();
            haprompt.GoToDashboard();

            Common trackermenu = new Common();
            trackermenu.ClickTrackerMenu();

            Page_OralHealthTracker pa = new Page_OralHealthTracker(softassertions);
            pa.VerifyOralHealthTracker();
            
            is_soft_assert = true;
            softassertions.AssertAll();
            //Common logout = new Common();
            //logout.LogOut();
        }
        /// <summary>
        /// Test Case:Verifies Tracker Chart
        /// </summary>
        [Test, Order(2)]
        [Category("Regression")]
        [Category("AllClientReg")]
        public void TC_VerifyTrackerChart()
        {
            //Page_Login plogin = new Page_Login();
            //plogin.Login();
            //Page_HAPrompt haprompt = new Page_HAPrompt();            
            //haprompt.GoToDashboard();

            CommonTracker pa = new CommonTracker(softassertions);
            pa.VerifyTrackerChart();

            is_soft_assert = true;
            softassertions.AssertAll();
            
            Common logout = new Common();
            logout.LogOut();
        }
    }
}
