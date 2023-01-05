using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using WebUI.Data;
using WebUI.Support;

namespace WebUI.StepDefinitions
{
    [Binding]
    public class AddJobStepDefinitions
    {
        private IWebDriver _webDriver;
        User user = new User();
        Job job = new Job();
        [Given(@"I navigate to site")]
        public void GivenInavigatetosite()
        {
            _webDriver = new ChromeDriver("C:\\Users\\Admin\\Desktop\\ChromeDricer108");
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [Given(@"I log in to site")]
        public void GivenIlogintosite()
        {
            var page = new LoginMenuPageObject(_webDriver);
            page.LogIn(user.Login, user.Password);
        }

        [Given(@"I navigate to site's section")]
        public void GivenINavigateToSitesSection()
        {
            var page = new SideBarMenuPageObject(_webDriver);
            page.AdminButton().JobButton().JobTitlesButton().AddJobButton();

        }

        [When(@"I add job information and save changes and verify whether the job is added")]
        public void WhenIAddJobInformation()
        {
            var page = new AddJobPageObject(_webDriver);
            if (page.AddJob(job.JobName, job.JobDescription, job.Note).IsElementExist(job.JobName))
                throw new InvalidOperationException("Does not exist");
        }

        [Then(@"I delete added job and verify the job is deleted")]
        public void ThenIDeleteAddedJob()
        {
            var page = new AdminMenuPageObject(_webDriver);
            page.DeleteJob(job.JobName);
            if (page.IsElementExist(job.JobName))
                throw new InvalidOperationException("Does exist");
        }

    }
}
