﻿using AutomationFramework.Framework;
using AutomationFramework.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Pages.WebPages.Courses
{
    class Page_QuitTobaccoCourse
    {
        String pageName;
        CommonCourses cc = null;
        SoftAssertions softassertions = null;
        /// <summary>
        /// The constructor will calculate current class name
        /// Which will be used by ElementLocator to get 'By' object.
        /// Our repository (Or_Web.xml) contains locators of each page which will be differentiated by classname
        /// </summary>
        public Page_QuitTobaccoCourse()
        {
            pageName = this.GetType().Name;
            Console.WriteLine("Current class : " + pageName);
        }

        public Page_QuitTobaccoCourse(SoftAssertions softassertions) : this()
        {
            this.softassertions = softassertions;
            cc = new CommonCourses(softassertions);
        }
        private void ClickQuitTobaccoCourse()
        {
            System.Threading.Thread.Sleep(2000);
            SeleniumKeywords.Click(pageName, "quittobaccocourse");
        }

        private void TakeCourse()
        {
            List<string[]> coursedata = CSVReaderDataTable.GetCSVData("CourseContent", pageName, "coursedata");

            for (int i = 0; i < coursedata.Count; i++)
            {
                string elementname = coursedata.ElementAt(i)[2];
                string elementlocatorname = coursedata.ElementAt(i)[3];
                string exptext = coursedata.ElementAt(i)[4];
                string actualtext = SeleniumKeywords.GetText(pageName, elementlocatorname);

                softassertions.Add("Element : " + elementlocatorname, exptext, actualtext, "contains");
            }

            StartLessonReading();
            cc.ConfirmCourse();


        }


        private void StartLessonReading()
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine("Value of i : " + i);
                List<string[]> courselessondata = CSVReaderDataTable.GetCSVData("CourseContent", pageName, "courselesson" + i + "data");
                for (int j = 0; j < courselessondata.Count; j++)
                {
                    Console.WriteLine("Value of j : " + j);
                    string elementname = courselessondata.ElementAt(j)[2];
                    string elementlocatorname = courselessondata.ElementAt(j)[3];
                    string exptext = courselessondata.ElementAt(j)[4];
                    if (!(exptext.Trim().Equals("no_element")))
                    {
                        string actualtext = SeleniumKeywords.GetText(pageName, elementlocatorname);
                        softassertions.Add("Element : " + elementlocatorname, exptext, actualtext, "contains");

                    }

                    if (j == 1)
                    {
                        Console.WriteLine("Clicking lesson1link ..... ");
                        System.Threading.Thread.Sleep(4000);
                        SeleniumKeywords.Click(pageName, "lesson" + i + "link");
                    }
                    else if (j == 2)
                    {
                        Console.WriteLine("Clicking Startlessonlink ..... ");
                        System.Threading.Thread.Sleep(4000);
                        SeleniumKeywords.Click(pageName, "quittobacco_startlesson_btn");
                    }
                    if (j >= 3 && j < courselessondata.Count - 1)
                    {
                        Console.WriteLine("Clicking Nextlessonlink ..... ");
                        System.Threading.Thread.Sleep(6000);
                        SeleniumKeywords.Click(pageName, "quittobacco_nextlesson_btn");
                    }
                    else if (j == courselessondata.Count - 1)
                    {
                        Console.WriteLine("Clicking Finishlessonlink ..... ");
                        System.Threading.Thread.Sleep(4000);
                        SeleniumKeywords.Click(pageName, "quittobacco_finishlesson_btn");
                    }
                    System.Threading.Thread.Sleep(4000);
                }
            }
        }
        public void CompleteQuitTobaccoCourse()
        {
            ClickQuitTobaccoCourse();
            TakeCourse();
        }
        public void NavigateToCourse()
        {
            ClickQuitTobaccoCourse();
        }
    }
}
