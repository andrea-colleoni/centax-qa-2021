using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Password
        {
            get
            {
                return driver.FindElement(By.Id("passwordInput"));
            }
        }
        public IWebElement Username
        {
            get
            {
                return driver.FindElement(By.Id("usernameInput"));
            }
        }
        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.Id("loginBtn"));
            }
        }
    }
}