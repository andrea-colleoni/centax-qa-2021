using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using Xunit;

namespace FunctionalTest
{
    public class ChromeTests
    {
        [Fact]
        public void PrimoTest()
        {
            var opts = new ChromeOptions();
            //opts.AddArguments("headless");
            opts.SetLoggingPreference(LogType.Browser, LogLevel.All);
            IWebDriver chrome = new ChromeDriver(opts);
            chrome.Url = "https://drm-demo.centaxtelecom.com/auth/login";
            chrome.Manage().Window.Maximize();
            
            Assert.Equal("DRM - Login", chrome.Title);
            // attesa
            chrome.Manage().Timeouts().ImplicitWait = new TimeSpan(1000);
            var page = new LoginPage(chrome);
            //Thread.Sleep(1000);
            page.Username.SendKeys("testuser");
            page.Password.SendKeys("password");

            // chrome.PageSource // sorgente della pagina
            chrome.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(5000);
            page.LoginButton.Click();

            Thread.Sleep(2000);
            Screenshot ss;
            try
            {
                var btn = chrome.FindElement(By.CssSelector("simple-snack-bar  > div > button > span.mat-button-wrapper"));

                if (btn.Text == "Errore")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }
            catch(NoSuchElementException e)
            {
                ss = ((ITakesScreenshot)chrome).GetScreenshot();
                ss.SaveAsFile(@"C:\Users\andre\Desktop\Temp\Corsi\Centax\Quality\ko.png", ScreenshotImageFormat.Png);
                Assert.True(false);
            }

            page.Username.Clear();
            page.Password.Clear();
            page.Username.SendKeys("emanuele_carantani");
            page.Password.SendKeys("Test123!");

            page.LoginButton.Click();
            
            //Thread.Sleep(2000);
            ss = ((ITakesScreenshot)chrome).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\andre\Desktop\Temp\Corsi\Centax\Quality\ok.png", ScreenshotImageFormat.Png);

            /*
            bool signalRSkipped = false;
            // see: https://stackoverflow.com/questions/57209503/system-nullreferenceexception-when-reading-browser-log-with-selenium
            foreach (var log in chrome.Manage().Logs.GetLog(LogType.Browser))
            {
                signalRSkipped = log.Message.Contains("SignalR Init skipped");
                if (signalRSkipped) break;
            }
            Assert.False(signalRSkipped);
            */

            // chrome.Navigate().GoToUrl("")
            //chrome.Close();
            chrome.Quit();
        }
    }
}
