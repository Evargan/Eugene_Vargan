using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Support
{
    internal class AdminMenuPageObject
    {
        private IWebDriver _webDriver;
        private static readonly By _jobMenuButton = By.XPath("//*[text() = 'Job ']");
        private static readonly By _jobTitlesButton = By.XPath("//*[text() = 'Job Titles']");
        private static readonly By _addJobButton = By.XPath("//button[text() = ' Add ']");
        private static readonly By _acceptDeleteButton = By.XPath("//button[text() = ' Yes, Delete ']");
        public AdminMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AdminMenuPageObject JobButton()
        {
            WaitUntil.WaitElement(_webDriver, _jobMenuButton);
            _webDriver.FindElement(_jobMenuButton).Click();
            return this;
        }

        public AdminMenuPageObject JobTitlesButton()
        {
            _webDriver.FindElement(_jobTitlesButton).Click();
            return this;
        }

        public AddJobPageObject AddJobButton()
        {
            WaitUntil.WaitElement(_webDriver, _addJobButton);
            _webDriver.FindElement(_addJobButton).Click();
            return new AddJobPageObject(_webDriver);
        }

        public AdminMenuPageObject DeleteJob(string str)
        {
            By _deleteJob = By.XPath($"//div[text() = '{str}']/parent::div/following-sibling::div/following-sibling::div/child::div/child::button");
            WaitUntil.WaitElement(_webDriver, _deleteJob);
            _webDriver.FindElement(_deleteJob).Click();
            _webDriver.FindElement(_acceptDeleteButton).Click();
            return this;
        }

        public bool IsElementExist(string str)
        {
            try
            {
                _webDriver.FindElement(By.XPath($"//div[text() = '{str}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
