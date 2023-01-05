using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Support
{
    internal class LoginMenuPageObject
    {
        private IWebDriver _webDriver;
        private static readonly By _passwordInputButton = By.XPath("//input[@name = 'password']");
        private static readonly By _loginInputButton = By.XPath("//input[@name = 'username']");
        private static readonly By _submitButton = By.XPath("//button[@type = 'submit']");

        public LoginMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public LoginMenuPageObject EnterLogin(string login)
        {
            WaitUntil.WaitElement(_webDriver, _loginInputButton);
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            return this;
        }

        public LoginMenuPageObject EnterPassword(string password)
        {
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            return this;
        }

        public LoginMenuPageObject Submit()
        {
            _webDriver.FindElement(_submitButton).Click();
            return this;
        }

        public SideBarMenuPageObject LogIn(string login,string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            Submit();
            return new SideBarMenuPageObject(_webDriver);
        }

    }
}
