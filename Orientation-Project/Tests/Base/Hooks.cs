using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using TechTalk.SpecFlow;

namespace Tests.Base
{
    [Binding]
    public sealed class Hooks :Driver
    {
        private ScenarioContext _scenerioContext;
        private FeatureContext _featureContext;
        public Hooks(ScenarioContext sceneriocontext,FeatureContext featureContext)
        {
            _scenerioContext = sceneriocontext;
            _featureContext = featureContext;
        }
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static string ReportPath;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

            string path = path1 + "Report\\TestReport.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {


            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<Scenario>(_scenerioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenerioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenerioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenerioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenerioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenerioContext.StepContext.StepInfo.Text);
            }
            else if (_scenerioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenerioContext.StepContext.StepInfo.Text).Fail(_scenerioContext.TestError.Message);

                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(_scenerioContext.StepContext.StepInfo.Text).Fail(_scenerioContext.TestError.Message);

                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(_scenerioContext.StepContext.StepInfo.Text).Fail(_scenerioContext.TestError.Message);

                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(_scenerioContext.StepContext.StepInfo.Text).Fail(_scenerioContext.TestError.Message);

                }
            }
        }





        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
            //driver.Quit();
        }


    }
}

