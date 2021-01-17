using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ClassLibrary1
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        private static ScenarioContext scenariocontext;
        private static FeatureContext featurecontext;
        private static ExtentReports extentreports;
        private static ExtentHtmlReporter extenthtmlreport;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            extenthtmlreport = new ExtentHtmlReporter("./Reports/");
            extentreports = new ExtentReports();
            extentreports.AttachReporter(extenthtmlreport);
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featurecontext)
        {
            if (null != featurecontext)
            {
                feature = extentreports.CreateTest<Feature>(featurecontext.FeatureInfo.Title,
                      featurecontext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext Scenariocontext)
        {

            if (null != Scenariocontext)
            {

                scenariocontext = Scenariocontext;
                scenario = feature.CreateNode<Scenario>(Scenariocontext.ScenarioInfo.Title,
                          Scenariocontext.ScenarioInfo.Description);
            }

        }

        [AfterStep]
        public void Aftereachstep()
        {

            ScenarioBlock scenarioblock = scenariocontext.CurrentScenarioBlock;
            switch (scenarioblock)
            {
                case ScenarioBlock.Given:
                    if (scenariocontext.TestError != null)
                    {
                        scenario.CreateNode<Given>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.Message + "\n" + scenariocontext.TestError.StackTrace);

                    }
                    else
                    {
                        scenario.CreateNode<Given>(scenariocontext.StepContext.StepInfo.Text).Pass("");
                    }

                    break;
                case ScenarioBlock.When:
                    if (scenariocontext.TestError != null)
                    {
                        scenario.CreateNode<When>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.Message + "\n" + scenariocontext.TestError.StackTrace);
                    }
                    else
                    {
                        scenario.CreateNode<When>(scenariocontext.StepContext.StepInfo.Text).Pass("");
                    }

                    break;
                case ScenarioBlock.Then:
                    if (scenariocontext.TestError != null)
                    {
                        scenario.CreateNode<Then>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.Message + "\n" + scenariocontext.TestError.StackTrace);
                    }
                    else
                    {
                        scenario.CreateNode<Then>(scenariocontext.StepContext.StepInfo.Text).Pass("");
                    }

                    break;
                default:
                    if (scenariocontext.TestError != null)
                    {
                        scenario.CreateNode<And>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.Message + "\n" + scenariocontext.TestError.StackTrace);
                    }
                    else
                    {
                        scenario.CreateNode<And>(scenariocontext.StepContext.StepInfo.Text).Pass("");
                    }
                    break;
            }

        }




        [AfterTestRun]
        public static void AfterTestrun()
        {

            extentreports.Flush();


        }





    }
}
