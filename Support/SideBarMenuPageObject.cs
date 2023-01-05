using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Support
{
    internal class SideBarMenuPageObject
    {
        private IWebDriver _webDriver;
        private static By _adminButton = By.XPath("//a[@href  = '/web/index.php/admin/viewAdminModule']");

        public SideBarMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public AdminMenuPageObject AdminButton()
        {
            WaitUntil.WaitElement(_webDriver, _adminButton);
            _webDriver.FindElement(_adminButton).Click();
            return new AdminMenuPageObject(_webDriver);
        }
    }
}
