using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Support
{
    internal class DefaultPageObject
    {
        protected IWebDriver _webDriver;

        protected DefaultPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
