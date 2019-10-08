﻿using AutomationFramework.Framework;
using AutomationFramework.Pages;
using AutomationFramework.Pages.WebPages.Coaching;
using AutomationFramework.Pages.WebPages.Trackers;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests.WebTests.Coaching
{
    [TestFixture]
    [Order(18)]
    public class ImproveBPGoal:Base
    {
        Common cmn = new Common();
        CommonGoals cmngoal = new CommonGoals();
        //[Test,Order(1)]
        //[Category("Regression")]
        public void GoToDashboard()
        {
            Page_Login plogin = new Page_Login();
            plogin.Login();
            Page_HAPrompt haprompt = new Page_HAPrompt();
            haprompt.GoToDashboard();

        }
        public void TC_InputBPStatus()
        {
            cmn.ClickGoalMenu();
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal();
            ibpg.InputBPValues();
            CommonGoals cg = new CommonGoals();
            cg.ClickStep1NextBtn();
        }
        //[Test,Order(2)]
        //[Category("Regression")]

        public void TC_VerifyPlanScreen()
        {
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal(softassertions);
            is_soft_assert = true;
            ibpg.VerifyPlanScreen();
            softassertions.AssertAll();
        }
        //[Test,Order(3)]
        //[Category("Regression")]

        public void TC_AddPlans()
        {
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal(softassertions);
            is_soft_assert = true;
            ibpg.VerifyActionsAdded();
            softassertions.AssertAll();
            
        }
        //[Test,Order(4)]
        //[Category("Regression")]
        public void TC_VerifyGoalSetUpScreen()
        {
            CommonGoals cg = new CommonGoals();
            cg.ClickStep2NextBtn();
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal(softassertions);
            is_soft_assert = true;
            ibpg.VerifySetUpScreen();
            softassertions.AssertAll();            
        }
        //[Test, Order(5)]
        //[Category("Regression")]
        public void TC_VerifyGoalCompletionScreen()
        {
            CommonGoals cg = new CommonGoals();
            cg.ClickConfirmBtn();
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal(softassertions);
            is_soft_assert = true;
            ibpg.VerifyGoalComplete();
            softassertions.AssertAll();

        }
        //[Test, Order(6)]
        //[Category("Regression")]
        public void TC_VerifyRemovePopUp()
        {
            //cmngoal.ClickRemoveBtn();
            CommonGoals cg = new CommonGoals(softassertions);
            is_soft_assert = true;
            cg.ClickRemoveBtn();
            cg.VerifyRemovePopUp();
            softassertions.AssertAll();
        }
        //[Test, Order(7)]
        //[Category("Regression")]
        public void TC_RemoveGoal()
        {
            CommonGoals cg = new CommonGoals(softassertions);
            cg.ClickRemoveScreenYesBtn();
        }
        public void NavigateToDashboard()
        {
            Page_Dashboard dashbrd = new Page_Dashboard();
            Assert.IsTrue(dashbrd.AtDashboard(), "Not Navigated to Dashboard");
        }
        //[Test, Order(1)]
        //[Category("Regression")]
        //[Category("CoachingReg")]
        public void TC_ClickInputScreenCancelButton()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            GoToDashboard();
            TC_InputBPStatus();
            cmngoal.ClickModalWindowCancelbutton();
            Assert.IsFalse(cmngoal.VerfiyModalWindowNotExist());
            cmngoal.ClickModalWindowOkButton();
            Page_HAPrompt haprompt = new Page_HAPrompt();
            haprompt.GoToDashboard();
            NavigateToDashboard();
            softassertions.AssertAll();
        }

        //[Test, Order(2)]
        //[Category("Regression")]
        //[Category("CoachingReg")]
        public void TC_ClickPlanScreenCancelButton()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            TC_InputBPStatus();
            TC_VerifyPlanScreen();
            cmngoal.ClickModalWindowCancelbutton();
            Assert.IsFalse(cmngoal.VerfiyModalWindowNotExist());
            cmngoal.ClickModalWindowOkButton();
            Page_HAPrompt haprompt = new Page_HAPrompt();
            haprompt.GoToDashboard();
            NavigateToDashboard();
            softassertions.AssertAll();
        }
        //[Test, Order(3)]
        //[Category("Regression")]
        //[Category("CoachingReg")]
        public void TC_ClickPlansBackBtn()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            TC_InputBPStatus();
            TC_VerifyPlanScreen();
            cmngoal.ClickStep1BackBtn();
        }
        //[Test, Order(4)]
        //[Category("Regression")]
        //[Category("CoachingReg")]
        public void TC_ClickGoalSetUpScreenCancelBtn()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            TC_InputBPStatus();
            TC_VerifyPlanScreen();
            TC_AddPlans();
            TC_VerifyGoalSetUpScreen();
            cmngoal.ClickModalWindowCancelbutton();
            Assert.IsFalse(cmngoal.VerfiyModalWindowNotExist());
            cmngoal.ClickModalWindowOkButton();
            Page_HAPrompt haprompt = new Page_HAPrompt();
            haprompt.GoToDashboard();
            NavigateToDashboard();
            softassertions.AssertAll();
        }
        //[Test, Order(5)]
        //[Category("Regression")]
        //[Category("CoachingReg")]
        public void TC_ClickGoalSetUpBackBtn()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            TC_InputBPStatus();
            TC_VerifyPlanScreen();
            TC_AddPlans();
            TC_VerifyGoalSetUpScreen();
            cmngoal.ClickStep2BackBtn();
            System.Threading.Thread.Sleep(4000);
            Page_ImproveBloodPressureGoal ibpg = new Page_ImproveBloodPressureGoal(softassertions);
            ibpg.ValidateAtActionsAdded();
            softassertions.AssertAll();
        }
        [Test,Order(6)]
        [Category("Regression")]
        [Category("CoachingReg")]
        //[Category("BuildSanity")]
        public void TC_ImproveBloodPressureGoal()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            GoToDashboard();//Removed once the bug is resolved(DELTA-340)
            TC_InputBPStatus();
            TC_VerifyPlanScreen();
            TC_AddPlans();
            TC_VerifyGoalSetUpScreen();
            TC_VerifyGoalCompletionScreen();

        }
        [Test, Order(7)]
        [Category("Regression")]
        [Category("CoachingReg")]
        //[Category("BuildSanity")]
        public void TC_FillBPTracker()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            Common trackermenu = new Common();
            //trackermenu.ClickTrackerMenu();
            Page_BPTracker bp = new Page_BPTracker(softassertions);
            bp.VerifyBPTracker();
            is_soft_assert = true;
            softassertions.AssertAll();
        }
        [Test, Order(8)]
        [Category("Regression")]
        [Category("CoachingReg")]
        //[Category("BuildSanity")]
        public void TC_RemoveImproveBPGoal()
        {
            Common config = new Common();
            string isenabled = config.GetConfig("CoachingEnabled").ElementAt(0)[1].ToLower();
            if (isenabled.Equals("false"))
            {
                Assert.Ignore("Coaching not enabled for client");
            }
            TC_VerifyRemovePopUp();
            TC_RemoveGoal();
            Page_HAPrompt haprompt = new Page_HAPrompt();//Removed once the bug is resolved(DELTA-340)
            haprompt.GoToDashboard();//Removed once the bug is resolved(DELTA-340)
            NavigateToDashboard();//Removed once the bug is resolved(DELTA-340)
            cmn.LogOut();
            softassertions.AssertAll();
        }

    }
}
