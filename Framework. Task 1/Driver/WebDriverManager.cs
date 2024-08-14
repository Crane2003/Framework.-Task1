using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework._Task_1.Driver
{
    public class WebDriverManager
    {
        private IWebDriver driver;

        public IWebDriver GetDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void QuitDriver()
        {
            driver.Quit();
            driver = null;
        }
    }

}
