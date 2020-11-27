using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace nunit_datadriven.commons
{
    public class InitBrowser
    {
        public static IWebDriver driver;

        // public ReadEnv env;
        public string browser = null;

        public InitBrowser()
        {
            //  env = new ReadEnv();
            //  browser = env.GetProperty("base", "browser");
        }

        public IWebDriver Getbrowser()
        {
            //string browser =
            //below line paramter value passed  "base" and "browser" from dev.ini file which is argument in
            //Readdata(section,key)method in ReadEnv.cs
            string browser = ReadEnv.ReadData("base", "browser");
            if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                // if (driver == null)
                // {
                var chromeOptions = new ChromeOptions();
                // chromeOptions.BrowserVersion = "67";
                // chromeOptions.PlatformName = "Windows 10";
                driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                return driver;
                //}
                // else
                //     return driver;
            }
            if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            {
                if (driver == null)
                {
                    driver = new FirefoxDriver();
                    return driver;
                }
                else
                    return driver;
            }
            return driver;
        }
    }
}