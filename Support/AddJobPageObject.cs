using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Support
{
    internal class AddJobPageObject
    {
        private IWebDriver _webDriver;
        private static readonly By _addJobName = By.XPath("//div[2]/input[@class = 'oxd-input oxd-input--active' ]");
        private static readonly By _addJobDescription = By.XPath("//textarea[@placeholder = 'Type description here']");
        private static readonly By _addNode = By.XPath("//textarea[@placeholder = 'Add note']");
        private static readonly By _saveButton = By.XPath("//button[text() = ' Save ']");
        public AddJobPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AddJobPageObject AddJobName(string str)
        {
            WaitUntil.WaitElement(_webDriver, _addJobName);
            _webDriver.FindElement(_addJobName).SendKeys(str);
            return this;
        }

        public AddJobPageObject AddJobDescription(string str)
        {
            _webDriver.FindElement(_addJobDescription).SendKeys(str);
            return this;
        }

        public AddJobPageObject AddNote(string str)
        {
            _webDriver.FindElement(_addNode).SendKeys(str);
            return this;
        }

        public AdminMenuPageObject SaveJob()
        {
            _webDriver.FindElement(_saveButton).Click();
            return new AdminMenuPageObject(_webDriver);
        }

        public AdminMenuPageObject AddJob(string JobName, string JobDescription, string Note)
        {
            AddJobName(JobName);
            AddJobDescription(JobDescription);
            AddNote(Note);
            return SaveJob();
        }

    }
}
